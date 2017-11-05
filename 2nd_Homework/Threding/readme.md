#Pitanje 1: 
	Izvođenje programa trajalo je nešto više od 5 sekundi.

#Pitanje 2:
	Operacije A,B,C,D i E su se sve izvodile na istoj dretvi.

#Pitanje 3:
	Sad je izvođenje programa trajalo nešto više od sekundu (1.186 sec).

#Pitanje 4:
	Operacije A,B,C,D i E su se izvodile na 5 različitih dretvi, odnosno svaka na svojoj.


#Pitanje 5:
	Neželjeno ponašanje događa se u sljedećem scenariju: neka dretva "A" pristupa zajedničkom sredstvu (counteru) dok on ima
	neku vrijednost x i uvećava ga za 1. U tom trenutku dretva "B" pristupa sredstvu (prije spremanja rezultata "A"). Dretva "A"
	sprema x+1 vrijednost, ali pošto je dretva "B" pristupila sredstvu prije spremanja rezultata od "A" ona će uvećati x za 1
	i spremiti ponovno x+1 u counter. Tako da iako bi rezultat nakon izvođenja te 2 dretve trebao biti x+2 on je x+1. Zbog 
	toga treba napraviti sinkronizaciju dretvi radi pristupa zajedničkom sredstvu.