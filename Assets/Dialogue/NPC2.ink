Hello, It's a nice day, right?
->main

=== main ===
I am the God of Gambling, 
and you have been chosen as one of my apostles 
for losing too much money

->Choose

=== Choose ===
Ready for Win a money?
    + [Yea!]
        Nice,
        -> choose("Gambling")
    + [Maybe]
            Sorry you have no choice,
        -> choose("Gambling")
    + [No]
            Sorry you have no choice,
        -> choose("Gambling")
        
    
        
        
        

=== choose(rest) ====
Have a nice at {rest}!
-> END


