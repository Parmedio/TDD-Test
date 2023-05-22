using TDD_Test;

var userInput = new List<string>
{
    "G1;V1;P1;100",
    "G2;V1;P1;100",
    "G3;V2;P1;100",
    "G4;V2;P1;100"
};

var work = new Services();
work.AssembleVariants(userInput);
