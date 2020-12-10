#GoldBadgeConsoleApplicationChallenge#

This is a collection of 8 console applications, each using new concepts, different elements, or a different approach.

                                        ****Challenge 1*****
My approach for Challenge 1 was to put most of the code and logic in the repo as opposed to the UI. This was my first time trying a program this way. I like how clean
it kept the UI. I also created and used more Helper Methods than I had previously. This drastically reduced the need for redundant code. Another first for me was using
a dictionary. I wanted to try it out to see how convenient the key value feature would be. This might not have been the most ideal program to implement it but it gave
me some good experience working with it. The dicitonary used was in the form <string, object>. I used string so I would not have to do so many Int.TryParse, but I had
wanted it to be a numerical key system and since the user is inputting numbers, I ended up having to parse a bunch of ReadLines. I am realizeing that maybe there is no
way around lots of parsing. To do over again, I might use  <int, object > style for the dictionary.  
I especially like the method for adjusting the keys after an item is delete, so the user still sees a numerical list starting at 1, with no gaps(lines 160-165).
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
