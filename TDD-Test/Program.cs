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


//PROVARE a fare passando una lista di liste oggetti

//var userInput = new List<string>
//{
//    G(1); V(1); P(1); 100,
//    G(2); V(1); P(1); 100,
//    G(3); V(2); P(1); 100,
//    G(4); V(2); P(1); 100
//};
