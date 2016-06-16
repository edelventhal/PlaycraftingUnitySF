# PlaycraftingUnitySF
Unity lessons and code for Playcrafting SF classes taught by Eli Delventhal.

There are two folders in here. The Lessons folder, and the FinalSolutions folder.

## Lessons
The Lessons have everything that was included in the lesson, including all the steps. Some of the steps will be commented out (only step 1 will be uncommented). Commenting something out means to make the compiler ignore it, so it basically just becomes text. If you want to follow along with each step, comment out previous steps, and uncomment the step you're on. The step numbers included in the comments should be clear about what you should comment out or not.

For example:

//STEP 1, 2, 3
/*
someCode();
*/

means that you should have that block uncommented during steps 1, 2, and 3, but once you go to step 4 you want to comment it out.

To uncomment code (make it work, for when you're on that step), you want to comment the /* and the */. That's not very intuitive, I know. You do that but adding a "//" like this:

//STEP 1, 2, 3
///*
someCode();
//*/

This causes someCode() to be called. You'll notice in your text editor that it's grayed out when it's a comment.

To recomment the code out again, just remove those //'s you added.

Some steps might say,

//STEP 5+
/*
someOtherCode();
*/

This means that as long as you're on step 5 or later, keep that code uncommented.

Make sure each time you move onto another step that you check all the source files for that step. For a given step, it may be that there are multiple things to do across multiple files.

## FinalSolutions
This folder has all the final steps worth of code and nothing else. So, basically, it's just a working example. If you just want something to work off of and mess with, this is the right place to go. I'd recommend duplicating the project instead of modifying this one, though.

## Need Help?
Please email me any questions you might have: eli.delventhal@gmail.com