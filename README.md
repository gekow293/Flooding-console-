# Flooding-console-

You are developing a 2D game. The field is a rectangle n×m (n rows
m cells in each).
Each field cell is either empty or contains a 1×1 stone block. When the game starts
blocks fall as far down as possible. The picture below illustrates this process.
![изображение](https://github.com/gekow293/Flooding-console-/assets/55548031/a549a534-c6e0-4eec-b336-6e8ee111686f)

After that, the field is flooded with water, which, under the influence of gravity, tends to leave
field. Consider that there is a void to the left and right of the field, and the field is located on
surface (that is, the lower boundary of the field does not allow water to pass through). As a result of this flood,
the field may remain water units. Water may remain on the field if it is blocked by blocks (use common sense and the illustration below to understand the rules of how
water remains on the field).
![изображение](https://github.com/gekow293/Flooding-console-/assets/55548031/4b623336-6665-4198-a749-bb8f347eea4d)

Write a program that, given the initial state of the field, will return its state after
flood.
Input data
The first line contains an integer t(1≤t≤10000) — the number of test cases in
test.
The descriptions of the sets follow.
The first line of the description contains two integers n, m (1≤n≤10000, 1≤m≤10000000) —
field sizes. It is guaranteed that the total number of cells in the field does not exceed 10^6 (then
there are n<m≤10^6).
Followed by n
lines by m
characters in each - the initial state of the field. Each line contains only characters '.'
(empty field cell) and '*' (stone block).
It is guaranteed that the sum of the number of cells over all test cases does not
exceeds 10000000
Output
For each test case, print the final state of the field. Water unit needed
symbolize (tilde).
After each field, print a newline.
as a result - a program that can be fed a text file as input and
get text file
