# pet-compiler
Implementation Compiler's of custom programming language by C#/.NET

Custom language grammer:
<program> ::= start nl <operlist1> nl end nl <br/>
<operlist1> ::= <operlist> <br/>
<operlist> ::= <oper> <br/>
<operlist> ::= <operlist> nl <oper> <br/>
<oper> ::= input ( id ) <br/>
<oper> ::= output ( <explist1> ) <br/>
<oper> ::= id <- <exp1> <br/>
<oper> ::= do while <logexp1> <operlist1> nl enddo <br/>
<oper> ::= if <logexp1> <operlist1> nl else <operlist1> nl endif <br/>
<explist1> ::= <explist> <br/>
<explist> ::= <exp1> <br/>
<explist> ::= <explist> , <exp1> <br/>
<exp1> ::= <exp> <br/>
<exp> ::= <term1> <br/>
<exp> ::= <exp> + <term1> <br/>
<exp> ::= <exp> - <term1> <br/>
<term1> ::= <term> <br/>
<term> ::= <mult> <br/>
<term> ::= <term> * <mult> <br/>
<term> ::= <term> / <mult> <br/>
<mult> ::= ( <exp1> ) <br/>
<mult> ::= id <br/>
<mult> ::= const <br/>
<mult> ::= - <mult> <br/>
<logexp1> ::= <logexp> <br/>
<logexp> ::= <logterm1> <br/>
<logexp> ::= <logexp> or <logterm1> <br/>
<logterm1> ::= <logterm> <br/>
<logterm> ::= <logmult> <br/>
<logterm> ::= <logterm> and <logmult> <br/>
<logmult> ::= [ <logexp1> ] <br/>
<logmult> ::= <rel> <br/>
<logmult> ::= not <logmult> <br/>
<rel> ::= <exp1> <logsign> <exp1> <br/>
<logsign> ::= > <br/>
<logsign> ::= < <br/>
<logsign> ::= = <br/>
<logsign> ::= >= <br/>
<logsign> ::= <= <br/>
<logsign> ::= >< <br/>
