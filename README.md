# [Gridland Metro](https://www.hackerrank.com/contests/world-codesprint-7/challenges/gridland-metro)

This repo is my code for the a problem from a Hackerrank challenge.

At its heart, the problem is taking a very large 2 dimensional array, up to 10^18 elements,
blacking out some elements, and counting how many elements remain in the array. Since the size
of the array is so large, working with it directly would cause the code to quickly become bogged
down. An easy work around is to just store the number of elements in memory as a BigInteger, then
count the number of blacked out "tracks" and subtract them. But, a caveat is that the tracks can
overlap each other, so we have to make sure we don't count the overlaps.

Using a bit of logic, I wrote the code so it would detect when intervals would overlap, and replace
the two intervals with the union of both of them. Not only does this take care of the problem of
over counting intersections, it also cuts down on memory usage and computation time.