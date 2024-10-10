Hello
->main

=== main ===
What would you prefer to do this weekend?
    + [Watch a movie]
        -> choose("movie theater")
    + [Go hiking]
        -> choose("mountain")
    + [Relax at home]
        -> choose("home")
        
    
        
        
        

=== choose(rest) ====
Have a nice at {rest}!
-> END