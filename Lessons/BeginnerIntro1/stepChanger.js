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
    "fa6d79eedfaeeb422e72a7ee2bd1e2d04b37639f",
    "8fc300580c760820c5fccecd406744d6514285e0",
    "c08e82029280686d152e392cfc9eb6db891daa6c",
    "d72b48c15240fdaf527eb4d043add58296344743",
    "87f40e9b8689b964741c95ef31821fa18e50310c",
    "92b484e3416e29c4c7ce442f921cc695d99377fb",
    "b5f9a26e0a3f7a63c93ab2964968e24037b628c6",
    "e23ec1eb52b3563a169966b8dfcd988d53b24f72",
    "8676a0874f65eecce6bcd99addede1ab360462e7",
    "7af7f97a98035ac9e5adec5503d1a2344bca79f4",
    "c2ee8273ada2e2209be5249d9810fa9799f98de6",
    "46e0d214c83ee8ae25167a5d2f6679869d0dda6c",
    "74bd98766da66dddd01af46a9aa501211be2ce46",
    "71d110d944f212886bac016c67163657d8bfebed",
    "a27c5ac8728edda4cdd8c59d5071e1b352ceeacd",
    "8dd9b6dd432ca4c290b6af8c1e184245858aaf60",
    "ae870af0fc89f9d7cfbd2abea96562f8fa299547",
    "595f4239a1e5c9aa6780a70a3fa9798095dbb4c8",
    "2bc712c0f06577355d00877f57630a5677b591d3"
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