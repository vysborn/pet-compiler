# pet-compiler
Implementation Compiler's of custom programming language by C#/.NET

Custom language grammer:

1. <program> ::= start nl <operlist1> nl end nl
2. <operlist1> ::= <operlist>
3. <operlist> ::= <oper>
4. <operlist> ::= <operlist> nl <oper>
5. <oper> ::= input ( id )
6. <oper> ::= output ( <explist1> )
7. <oper> ::= id <- <exp1>
8. <oper> ::= do while <logexp1> <operlist1> nl enddo
9. <oper> ::= if <logexp1> <operlist1> nl else <operlist1> nl endif
10. <explist1> ::= <explist>
11. <explist> ::= <exp1>
12. <explist> ::= <explist> , <exp1>
13. <exp1> ::= <exp>
14. <exp> ::= <term1>
15. <exp> ::= <exp> + <term1>
16. <exp> ::= <exp> - <term1>
17. <term1> ::= <term>
18. <term> ::= <mult>
19. <term> ::= <term> * <mult>
20. <term> ::= <term> / <mult>
21. <mult> ::= ( <exp1> )
22. <mult> ::= id
23. <mult> ::= const
24. <mult> ::= - <mult>
25. <logexp1> ::= <logexp>
26. <logexp> ::= <logterm1>
27. <logexp> ::= <logexp> or <logterm1>
28. <logterm1> ::= <logterm>
29. <logterm> ::= <logmult>
30. <logterm> ::= <logterm> and <logmult>
31. <logmult> ::= [ <logexp1> ]
32. <logmult> ::= <rel>
33. <logmult> ::= not <logmult>
34. <rel> ::= <exp1> <logsign> <exp1>
35. <logsign> ::= >
36. <logsign> ::= <
37. <logsign> ::= =
38. <logsign> ::= >=
39. <logsign> ::= <=
40. <logsign> ::= ><
