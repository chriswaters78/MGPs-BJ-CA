# Wizard of Odds Spanish 21 H17 redoubling chart

From https://wizardofodds.com/games/spanish-21/ ("Double Double Down, Dealer Hits on Soft 17, Player Has Not Already Doubled").

6 decks, dealer hits soft 17, all bonuses except the super bonus, player 21 always wins, double and redouble up to 8 units.

| Strategy | EV |
|---|---|
| Composition dependent | -0.4108% |
| 2-card dependent | -0.4175% |
| Total dependent | -0.4299% |
| This chart | -0.4128% |

| Hard | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | T | A |
|---|---|---|---|---|---|---|---|---|---|---|
| 5 | H | H | H | H | D | H | H | H | H | H |
| 6 | H | H | H | H | D | H | H | H | H | H |
| 7 | H | H | H | H | D | H | H | H | H | H |
| 8 | H | H | H | D | D | H | H | H | H | H |
| 9 | H | D4 | D | D | D | H | H | H | H | H |
| 10 | D5 | D5 | D | D | D | D | D5 | H | H | H |
| 11 | D4 | D5 | D5 | D5 | D5 | D5 | D5 | D4 | D3 | D3 |
| 12 | H | H | H | H | H | H | H | H | H | H |
| 13 | H | H | H | H | S4* | H | H | H | H | H |
| 14 | H | H | S4* | S5 | S6 | H | H | H | H | H |
| 15 | S4* | S5 | S6 | S6 | S | H | H | H | H | H |
| 16 | S6 | S6 | S6 | S | S | H | H | H | H | RH |
| 17 | S | S | S | S | S | S6 | S6 | S6 | S6 | RH |
| 18 | S | S | S | S | S | S | S | S | S | S |
| 19 | S | S | S | S | S | S | S | S | S | S |
| 20 | S | S | S | S | S | S | S | S | S | S |
| 21 | S | S | S | S | S | S | S | S | S | S |

| Soft | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | T | A |
|---|---|---|---|---|---|---|---|---|---|---|
| 13 (A,2) | H | D3 | D | D | D | H | H | H | H | H |
| 14 (A,3) | H | D3 | D4 | D | D | H | H | H | H | H |
| 15 (A,4) | H | H | D4 | D4 | D5 | H | H | H | H | H |
| 16 (A,5) | H | H | D3 | D4 | D5 | H | H | H | H | H |
| 17 (A,6) | H | H | D3 | D4 | D5 | H | H | H | H | H |
| 18 (A,7) | S4 | S4 | D4 | D5 | D6 | S6 | S4 | H | H | H |
| 19 (A,8) | S | S | S | S | S | S | S | S | S6 | S6 |
| 20 (A,9) | S | S | S | S | S | S | S | S | S | S |
| 21 (A,T) | S | S | S | S | S | S | S | S | S | S |

| Pair | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | T | A |
|---|---|---|---|---|---|---|---|---|---|---|
| 2,2 | P | P | P | P | P | P | P | H | H | H |
| 3,3 | P | P | P | P | P | P | P | H | H | H |
| 4,4 | H | H | H | D | D | H | H | H | H | H |
| 5,5 | D | D | D | D | D | D | D | H | H | H |
| 6,6 | H | H | P | P | P | H | H | H | H | H |
| 7,7 | P | P | P | P | P | P | H | H | H | H |
| 8,8 | P | P | P | P | P | P | P | P | P | R |
| 9,9 | S | P | P | P | P | S | P | P | S | S |
| T,T | S | S | S | S | S | S | S | S | S | S |
| A,A | P | P | P | P | P | P | P | P | P | P |

H hit, S stand, D double, P split, RH surrender if allowed otherwise hit, RS surrender if allowed otherwise stand.
A number after a play is a card count: D4 = double, but hit with 4 or more cards; S6 = stand, but hit with 6 or more cards.
\* = hit the two-card hand that can still make 6-7-8 (6,7 v 6; 6,8 v 4; 7,8 v 2). Never split 4s, 5s or 10s.

The Wizard's suit-dependent cells (hit 6,8 v 5 or 7,8 v 3 if suited, 6,8 v 6 if spades, and the super bonus exceptions for 7,7) can't be expressed: the CA's strategies don't see suits, so they use the unsuited play.

## After doubling

The Wizard's "Player Has Already Doubled" chart: S stand, D double again (up to 8 units), R rescue.

| Hard | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | T | A |
|---|---|---|---|---|---|---|---|---|---|---|
| 6 | S | D | D | D | D | D | R | R | R | R |
| 7 | D | D | D | D | D | D | R | R | R | R |
| 8 | D | D | D | D | D | D | D | D | R | R |
| 9-11 | D | D | D | D | D | D | D | D | D | D |
| 12 | S | S | S | S | S | D | D | R | R | R |
| 13-16 | S | S | S | S | S | S | R | R | R | R |
| 17 | S | S | S | S | S | S | S | S | S | R |
| 18-21 | S | S | S | S | S | S | S | S | S | S |

| Soft | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | T | A |
|---|---|---|---|---|---|---|---|---|---|---|
| 13-17 | D | D | D | D | D | D | D | D | D | D |
| 18 | S | S | D | D | D | S | S | S | S | S |
| 19-21 | S | S | S | S | S | S | S | S | S | S |

A forced strategy can't set the play after a double: the CA always picks stand, redouble or rescue as the best play for the exact cards, which is what the EVs above assume. Playing doubled hands by this chart instead costs about 0.0001%. A rescue loses half the current stake: the original bet after one double, the bet before the redouble after a redouble.
