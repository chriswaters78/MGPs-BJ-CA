# CDZ- should read the suits of the player's own cards

A note on the combinatorial analyser in `claude-plays-blackjack`, from a comparison with MGP's BJ CA on Spanish 21
(6 Spanish decks, H17, peek, every bonus, the rescue). Every figure below was produced by one of the two analysers
or worked out exactly by hand, as marked.

**Status: fixed** on `feature/spanish21` in `e3b90e6`. See [After the fix](#after-the-fix) for the rerun against MGP.
The rest of the note describes the analyser before that commit.

## Summary

In games with suited bonuses (the 6-7-8 and 7-7-7 paying more when the three cards share a suit, more again in
spades), the analyser's CDZ- picks one play for each hand by its card values and prices hitting at the *average*
chance that the bonus hand comes out suited. A zero-memory player remembers only the cards of the hand being played,
but those cards' suits are part of what they hold: 6♠7♠ and 6♠7♥ are different hands to them. So CDZ- as it
stands:

1. **understates the best zero-memory play** by about 0.0005% to 0.0007% a round at H17, the value of playing the
   two-card 6-7-8 hands (6,7, 6,8, 7,8) and 7,7 by whether their cards share a suit; and
2. **when bonuses aren't paid on split hands, forces a bonus-driven play onto split hands that can't earn the
   bonus**, because CDZ- plays a split hand as the unsplit hand of the same cards. That costs another 0.0010% a
   round in the test game below.

## Why suits belong in CDZ-

Zero memory means the player's information is the hand in front of them and the up-card: no other hands, no
earlier rounds. The suits of the hand's own cards (and of the up-card) are in plain sight. Without suit-dependent
payouts they don't affect any decision, which is why a CA can normally drop them; with suited bonuses they change
the value of hitting.

`comp.rs` says "a strategy reading values never looks at suits". That is right for a strategy *chart*, which is keyed
by totals and values, and the strategy app already handles suits there with the suited 6-7-8 exceptions ("S sH":
stand, but hit when suited). But CDZ- isn't a chart: it is meant to be the best play for each hand the player can
hold. The analyser already works out per-suit values for starts (`Ca::suit_cases`, `analyser.rs:869`, split by
suit and whether the up-card shares it); the round just doesn't choose plays by them.

## Example: 7,8 against a 3

Test game: H17, no redoubling, bonuses not paid on split hands, 6-7-8 paying 3:2 and 2:1 when suited (no spades
payout, no 7-7-7). Figures are the analyser's own (`--up 3 --hand 7,8`), the suited hit derived from them:

| 7,8 v 3 | Stand | Hit |
|---|---|---|
| Unsuited (3/4 of 7,8s) | −32.066% | −32.311% |
| Suited (1/4; a 6 of the suit pays 2:1) | −32.066% | −31.26% |
| Averaged over suits, as CDZ- sees it | −32.066% | −32.048% |

- **CDZ- now:** hit every 7,8, −32.048%.
- **Reading suits:** hit when suited, stand when not: 3/4 × −32.066% + 1/4 × −31.26% = −31.86%, 0.18% better per
  hand.

Summed over the cells where the suits change the play (6,8 v 5 and 6, 7,8 v 3–6, the spades cases, 7,7), this is
the 0.0005% the analyser's own `SPANISH21.md` gives for "playing 6-7, 6-8, 7-8 and 7-7 by their suits" at H17.
MGP's CA, whose best play reads suits on these starts, adds 0.0004% to the one-suit step and 0.0003% to the spades
step over the exact fixed-play values (below).

## The split-hand side effect

Adding the one-suit payout in the test game should only raise the EV. Against a 3 it lowers it (+6.341% to +6.337%
given the up-card). Per start (`--json`):

| Start v 3 | Without the suited payout | With it |
|---|---|---|
| 7,7, split | −17.023% | −17.875% |
| 8,8, split | −0.201% | −1.039% |
| 6,7, hit | −21.689% | −21.426% |
| 6,8, hit | −27.068% | −26.805% |
| 7,8 | −32.066% (stand) | −32.048% (hit) |

Unsplit, 7,8 v 3 now hits (the averaged row above). CDZ- makes the split 7,8s hit too, but in this game a split
hand can't earn the bonus, so for them hitting is just −32.311% against standing at −32.066%. That is −0.0114%
given a 3, −0.0010% a round, and it is all of the gap between CDZ- and the exact value of the suited payout:

| Suited step, test game | One suit 2:1 | Spades 3:1 (added) |
|---|---|---|
| Exact, by hand, fixed plays | 0.0087% | 0.0044% |
| This analyser, CDZ- | 0.0077% | 0.0035% |
| This analyser, CDP1 | 0.0087% | 0.0045% |
| MGP's CA (reads suits on starts) | 0.0091% | 0.0047% |

The exact value counts each two-card 6-7-8 start the play hits (6,7 always; 6,8 except v 5, 6; 7,8 except v 3–6),
the dealer having no blackjack, the third card completing it, all three of one suit (1/16) and the 0.5 extra.

Reading suits would shrink this: an unsuited 7,8 v 3 would stand unsplit, so only the suited split 7,8s (1/4)
would still carry the forced hit. With bonuses paid on split hands (the presets' `BAS`) a split 7,8 can earn the
bonus, so the hit is right for it and there's no side effect.

## Suggested change

For starts that can still make a suited bonus (6,7, 6,8, 7,8 and 7,7), choose CDZ-'s play per suit case, as
`suit_cases` already values them: the round takes Σ over cases of p × the best action's EV in that case, instead of
the best action of the averaged EVs. With bonuses paid on split hands, split hands would read the same suit cases.
The up-card's suit is visible too, and `suit_cases` already splits on it (`up_suited`), so it can be included at
no extra cost.

Expected effect: CDZ- about 0.0005–0.0007% better at H17 (the redoubling preset's 0.4175% to about 0.417%), and
nearer still in games that don't pay bonuses on split hands.

Checks: in the test game above, the one-suit step should be at least the exact 0.0087% (CDP1 already gives it), and
the spades step at least 0.0044%; 7,7 v 3 and 8,8 v 3 split EVs should fall by much less than now when the suited
payout is added.

## After the fix

`e3b90e6` ("CDZ- and the simulator read the suits of a bonus start, and every split path pays suited bonuses")
plays 6,7, 6,8, 7,8 and 7,7 by suit case, and where no bonus is paid on split hands, plays those split hands as a
start of mixed suits. Rerun against MGP's BJ CA at `6c24a72` (with the suited-bonus fixes), both to six decimals.

Test game, as above (no 7-7-7, no bonuses on split hands):

| Step | MGP CD | CDZ- now | CDZ- before |
|---|---|---|---|
| 5/6/7-card 21 only | −0.961219% | −0.961219% | |
| + 6-7-8 3:2 | −0.828448% | −0.828448% | |
| + one suit 2:1 | −0.819304% (+0.009144) | −0.819329% (+0.009119) | +0.0077 |
| + spades 3:1 | −0.814635% (+0.004669) | −0.814673% (+0.004656) | +0.0035 |
| 7,7 v 3 split, without → with the suited payout | −17.023% → −17.023% | −17.023% → −17.023% | −17.023% → −17.875% |
| 8,8 v 3 split, without → with the suited payout | −0.201% → −0.201% | −0.201% → −0.201% | −0.201% → −1.039% |

Both points in the summary are resolved: CDZ- now takes the full value of the suited payouts (CDP1 gives the
same steps), and adding the suited payout no longer changes the split hands.

Full presets (every bonus but the super bonus):

| Game | MGP CD | CDZ- | CDP1 | CDZ- − MGP |
|---|---|---|---|---|
| H17, no bonuses on split hands | −0.802067% | −0.802106% | −0.799380% | −0.000039% |
| H17, bonuses on split hands | −0.778132% | −0.776829% | −0.776781% | +0.001303% |
| H17 two redoubles, no bonuses on split hands | −0.440594% | −0.440618% | −0.438207% | −0.000024% |
| H17 two redoubles, bonuses on split hands | −0.418174% | −0.416852% | −0.416765% | +0.001322% |

- **Same bonuses on both sides:** with no bonuses on split hands the two analysers agree to within 0.00004%, the
  same small difference as in the suited steps above. MGP is the higher of the two there, although the analyser
  also reads the up-card's suit; which side is right at that size hasn't been looked into.
- **Bonuses on split hands:** MGP pays the ordinary bonuses on split hands but not the suited and spades payouts.
  The analyser now pays them, worth about 0.0013% a round, which is the whole gap. Before the fix the gap was
  0.0007%, because CDZ- missing the value of reading suits hid part of it.
