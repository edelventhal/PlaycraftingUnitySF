/*global require*/
/*global process*/
/*global console*/

var exec = require('child_process').exec;
var readline = require('readline');
var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

var shas =
[
    "4e9c40a441fb64d07ff11245369c5991a7e833bc",
    "c9923530a49e92f51e9881651ac802c452413801",
    "9969f37f7d1d2f9ae001f9ea4baba42ca44b0196",
    "6bcb0427615dd9716a8f73e11e76a27af8253ee7",
    "bbe7cfb85f7febedb510a1b5067193a730d0bd34",
    "32b7e8e041b501bab1da1813c0954d8a1b6b88cf",
    "3e1269c2a631f0ef6f240b4ecca7479ce5f4e23f",
    "d433a24d42f17d932a4e50e9892056ba3d8eabf3",
    "a3c880689e3a878addb159fb2e967cb19ffeaf90",
    "3ee94669ef446aca8379c36e47c9bef42c43dac7",
    "73c293707fa3488efbc591ffc14d21b5bfd03a13",
    "18c8cee72a4a31a77b20b6fe15049618049e4407",
    "6949d690f230eb64c9c962e26fb33d3f82b6df76",
    "88423e45235289fe52a1775ca7b2b584dc530147",
    "548d52f8dd3abbb0a49514c100c63385b7c6b5de"
];
shas.reverse();
var currentStep = 0;
console.log( "Found " + shas.length + " steps." );

var goToStep = function( stepNumber, cb )
{
    currentStep = stepNumber;
    
    console.log( "Going to step " + currentStep );
    exec( "git reset --hard HEAD; git checkout " + shas[currentStep], cb );
};

var goToNextStep = function( cb )
{
    goToStep( Math.min( currentStep + 1, shas.length - 1 ), cb );
};

var promptAnswer = "";
var showPrompt = function( cb )
{
    rl.question('?', cb );
};

// var continueFunc = function()
// {
//     if ( promptAnswer !== "d" && promptAnswer !== "done" )
//     {
//         showPrompt( promptResponseFunc );
//     }
// };

var promptResponseFunc = function( answer )
{
    promptAnswer = answer;

    if ( promptAnswer === "start" )
    {
        goToStep(0, function()
        {
            showPrompt( promptResponseFunc );
        });
    }
    else if ( promptAnswer.charAt(0) === "s" )
    {
        goToStep( Math.floor(promptAnswer.substring(1) ), function()
        {
            showPrompt( promptResponseFunc );
        } ); 
    }
    else if ( promptAnswer === "n" )
    {
        if ( currentStep < shas.length - 1 )
        {
            goToNextStep(function()
            {
                showPrompt( promptResponseFunc );
            });
        }
    }
    else if ( promptAnswer === "d" || promptAnswer === "done" )
    {
        process.exit();
    }
};

showPrompt( promptResponseFunc );