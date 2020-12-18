#GoldBadgeConsoleApplicationChallenge#

This is a collection of 8 console applications, each using new concepts, different elements, or a different approach.

                                        ****Challenge 1*****
My approach for Challenge 1 was to put most of the code and logic in the repo as opposed to the UI. This was my first time trying a program this way. I like how clean
it kept the UI. I also created and used more Helper Methods than I had previously. This drastically reduced the need for redundant code. Another first for me was using
a dictionary. I wanted to try it out to see how convenient the key value feature would be. This might not have been the most ideal program to implement it but it gave
me some good experience working with it. The dicitonary used was in the form <string, object>. I used string so I would not have to do so many Int.TryParse, but I had
wanted it to be a numerical key system and since the user is inputting numbers, I ended up having to parse a bunch of ReadLines. I am realizing that maybe there is no
way around lots of parsing. To do over again, I might use  <int, object > style for the dictionary.  
I especially like the method for adjusting the keys after an item is deleted, so the user still sees a numerical list starting at 1, with no gaps(lines 160-165).
The program is clean and fully functional and accounts for all invalid user input.

                                      *****Challenge 2******
                                     

I learned that I went about Challenge 1 the wrong way and should not have had so much user interaction in the repo.  Therefore, moving forward, all Console.ReadLine()s 
will be in the UI only.  This project implements a queue instead of a list or dictionary.  This was my first time working with a queue.  The queue has nice functionality. 
I tried a few other things for the first time as well.  By adding a reference, I was able to use helper methods from another project.  Another first was using a string 
remove feature to limit the number of characters that get printed to the screen if it is a particularly long description.  The program is fully functional and user friendly.

                                     ******Challenge 3******
                                     
I have since learned that the repo must not contain any Console.Write()s either.  It should contain single purpose methods only.  All read and write lines should be in the
UI and that is the case for this project.  The requirement was to use a dictionary, which I now have experience using.  I worked on a couple new concepts for this program.
I created a submenu, where I could have just set up some y/n questions about what the user would like to do next.  The submenu is not very large, but I just wanted to
see how it would work.  It turned out well and I will be using it again.  I used a sort feature when printing the list of doors for the user so even if doors get added
on, it shows them in a nice sequential order.  When adding or removing doors, the list is updated so user only sees which ones are available.  The code is very clean compared
to the previous two challenges.  

                                    ******Challenge 4*******
                                   
This challenge gave me an opportunity to try a few new things.  First off, I learned how to implement a calculation into one of the object properties.  So the totoal event cost 
has a get only with a return of the calculation from two other properties.  There is no setter so it cannot be set outside of this calculation.  A second thing I implemented
for the first time was a tactic for adding an unlimited number of objects at one time by using an overload of an array in my add method in the repo.  It came in handy while
seeding the UI.  I am interested to see how useful this could be in other situations.  Also I used "try/catch" in place of an if statement to learn how those work.  Lastly, 
I used string formatting to manipulate how number, dollars, and decimal places will print to the console.  

                                  ******Challenge 5********
                                  
This program is used to mimic a database of customers and their status.  Each customer will get sent an email based on their status.  The status is either current customer, 
previous customer, or prospective customer and the emails are drafted appropriately.  This program makes use of inheritance by creating an abstract person object and inheriting
those properties into the customer object.  I then use the customer object in another challenge in this same solution later.  A first time in this assembly was using string
formatting to line up a table, as opposed to using \t\t\t so much.  I also made a change to my Yes/No helper method and removed the goto and label scheme from it.  Also inlcuded
in the UI is a search method.  This allows the user to search for a customer without knowing all of their information.  

                                 ******Challenge 6*********
                                 
                                 
                                 ******Challenge 7*********
                                 
                                 
                                 ******Challenge 8********

In this challenge we were given the most freedom.  It was really fun to get creative with objects and properties.  I was able to call and inherit from multiple challenges
and classes.  Additonally, I discovered how to build more extensive logic into the properties.  
