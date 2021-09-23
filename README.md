# pet-compiler
Implementation Compiler's of custom programming language by C#/.NET

Custom language grammer:
<program> ::= start nl <operlist1> nl end nl
<operlist1> ::= <operlist>
<operlist> ::= <oper>
<operlist> ::= <operlist> nl <oper>
<oper> ::= input ( id )
<oper> ::= output ( <explist1> )
<oper> ::= id <- <exp1>
<oper> ::= do while <logexp1> <operlist1> nl enddo
<oper> ::= if <logexp1> <operlist1> nl else <operlist1> nl endif
<explist1> ::= <explist>
<explist> ::= <exp1>
<explist> ::= <explist> , <exp1>
<exp1> ::= <exp>
<exp> ::= <term1>
<exp> ::= <exp> + <term1>
<exp> ::= <exp> - <term1>
<term1> ::= <term>
<term> ::= <mult>
<term> ::= <term> * <mult>
<term> ::= <term> / <mult>
<mult> ::= ( <exp1> )
<mult> ::= id
<mult> ::= const
<mult> ::= - <mult>
<logexp1> ::= <logexp>
<logexp> ::= <logterm1>
<logexp> ::= <logexp> or <logterm1>
<logterm1> ::= <logterm>
<logterm> ::= <logmult>
<logterm> ::= <logterm> and <logmult>
<logmult> ::= [ <logexp1> ]
<logmult> ::= <rel>
<logmult> ::= not <logmult>
<rel> ::= <exp1> <logsign> <exp1>
<logsign> ::= >
<logsign> ::= <
<logsign> ::= =
<logsign> ::= >=
<logsign> ::= <=
<logsign> ::= ><
