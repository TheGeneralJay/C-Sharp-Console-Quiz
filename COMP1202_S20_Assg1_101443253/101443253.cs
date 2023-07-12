namespace COMP1202_S20_Assg1_101443253
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
               FFXIV Quiz Created By: Amanda Gurney 
               Student ID: 101443253
               Course Code: COMP1202
               Last Modified: June 18th, 2023 
               Application Name: How Well Do You Know Final Fantasy XIV?

               ================================================================================================

               Please Note:
               Anything used in this assignment that was not explicitly discussed in class
               was implemented after careful research online. I experimented with a few different
               things and learned a lot about C# in the process. I have tried to leave comments
               describing what most lines do, especially if it was something that was a product of
               my own research rather than lecture / lab knowledge.
            
               Features Implemented:
                    - Clear the screen after every question to improve readability and avoid user confusion.
                    - Confirmation required if user attempts to submit the same incorrect answer more than once.
                    - Confirmation required for name input so that the user is content with the name they've given.
                    - Anonymous user is documented as such on the scorecard if they chose to leave the name blank.
                    - User score per question is given when the user selects the correct answer. 
                    - Implemented a brief 'Enter' confirmation before moving on so that the user has room to breathe
                      before being hit with walls of text.
                    - User percentage score is rounded to two decimal places to improve readability while still
                      offering accurate result feedback.

            */

            // --------------------------
            // NAME INPUT VARIABLES 
            // --------------------------

            // User first, last and full name variables.
            string firstName, lastName, fullName;
            // Loop and if statement condition.
            bool userRestart = true;
            string userChoice;

            // --------------------------
            // QUIZ VARIABLES
            // --------------------------

            bool quizContinue = false;
            double userScore = 0;
            double percentageScore;

            // Track score of each individual question for accurate score card.
            int questionOneScore = 0,
                questionTwoScore = 0,
                questionThreeScore = 0;
            bool confirmationChoice = false;

            // Correct answers.
            string questionOneAnswer,
                   questionTwoAnswer,
                   questionThreeAnswer,
                   userConfirmation;

            // Question One.
            bool aOneAnswer = false,
                 cOneAnswer = false,
                 dOneAnswer = false;
            int questionOneAttempts = 0;

            // Question Two.
            bool bTwoAnswer = false,
                 cTwoAnswer = false,
                 dTwoAnswer = false;
            int questionTwoAttempts = 0;

            // Question Three.
            bool aThreeAnswer = false,
                 bThreeAnswer = false,
                 cThreeAnswer = false;
            int questionThreeAttempts = 0;


            // --------------------------
            // APPLICATION INTRODUCTION
            // --------------------------
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("| Welcome to the 'How Well Do You Know Final Fantasy XIV?' Quiz!   |");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("| This is a quiz designed to test your knowledge on the hit MMORPG |");
            Console.WriteLine("|                 game named Final Fantasy XIV.                    |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();

            // --------------------------
            // NAME INPUT
            // --------------------------
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|     Let's start with your name. Please enter your first name:    |");
            Console.WriteLine(".__________________________________________________________________.");

            Console.WriteLine("====================================================================");
            firstName = Console.ReadLine();
            Console.WriteLine("====================================================================");

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine($" Thank you, {firstName}! Please enter your last name:            ");
            Console.WriteLine(".__________________________________________________________________.");

            Console.WriteLine("====================================================================");
            lastName = Console.ReadLine();
            Console.WriteLine("====================================================================");

            // Verify that user is happy with their input.
            while (userRestart)
            {

                Console.WriteLine(".------------------------------------------------------------------.");
                Console.WriteLine($"  You've given the name {firstName} {lastName}");
                Console.WriteLine("  Is this correct? Please enter (Y) Yes, or (N) No: ");
                Console.WriteLine(".__________________________________________________________________.");

                Console.WriteLine("====================================================================");
                userChoice = Console.ReadLine();
                Console.WriteLine("====================================================================");

                if (userChoice == "y" || userChoice == "Y")
                {
                    userRestart = false;
                    Console.WriteLine(".------------------------------------------------------------------.");
                    Console.WriteLine($"  Thanks, {firstName} {lastName}! Let's start the quiz.");
                    Console.WriteLine(".------------------------------------------------------------------.");
                    Console.WriteLine("| When you are ready to start the quiz, please press Enter.        |");
                    Console.WriteLine(".__________________________________________________________________.");
                    Console.ReadLine();

                    // Console.Clear() will clear the screen to make things more readable.
                    Console.Clear();
                }
                // Allow user to re-input their name if they want to.
                else if (userChoice == "n" || userChoice == "N")
                {
                    Console.WriteLine(".------------------------------------------------------------------.");
                    Console.WriteLine(" No problem! Let's restart.");
                    Console.WriteLine(" Please enter your first name: ");
                    Console.WriteLine(".__________________________________________________________________.");

                    Console.WriteLine("====================================================================");
                    firstName = Console.ReadLine();
                    Console.WriteLine("====================================================================");

                    Console.WriteLine(".------------------------------------------------------------------.");
                    Console.WriteLine($"  Thank you, {firstName}! Please enter your last name: ");
                    Console.WriteLine(".__________________________________________________________________.");

                    Console.WriteLine("====================================================================");
                    lastName = Console.ReadLine();
                    Console.WriteLine("====================================================================");
                }
                else
                {
                    Console.WriteLine(".------------------------------------------------------------------.");
                    Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                    Console.WriteLine(".__________________________________________________________________.");
                    Console.ReadLine();
                }
            }

            // If user input is blank, scorecard will refer to them as anonymous.
            if (firstName == "" && lastName == "")
            {
                fullName = "Anonymous";
                firstName = "Anonymous";
                lastName = "Anonymous";
            }
            else
            {
                fullName = $"{firstName} {lastName}";
            }

            // --------------------------
            // QUIZ INTRODUCTION
            // --------------------------
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|               How Well Do You Know Final Fantasy XIV?            |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("| In this quiz, you will be asked three basic questions to test    |");
            Console.WriteLine("| your knowledge. You will be presented with four answer options,  |");
            Console.WriteLine("| (a, b, c, or d). Simply input the letter corresponding to the    |");
            Console.WriteLine("| answer that you want to choose. The application will inform you  |");
            Console.WriteLine("|             if your answer was correct or not.                   |");
            Console.WriteLine(".__________________________________________________________________.");

            Console.WriteLine();

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("| What happens if you accidentally enter the same incorrect answer |");
            Console.WriteLine("| twice? No problem! You will be asked to confirm if you would     |");
            Console.WriteLine("|        like to resubmit the same incorrect response.             |");
            Console.WriteLine(".__________________________________________________________________.");

            Console.WriteLine();

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                      Press Enter to begin!                       |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.ReadLine();
            Console.Clear();

            // --------------------------
            // QUESTION ONE
            // HOW MANY PLAYERS CAN JOIN A TYPICAL DUNGEON DUTY?
            // --------------------------
            while (quizContinue == false)
            {
                confirmationChoice = false;

                Console.WriteLine(".------------------------------------------------------------------.");
                Console.WriteLine("|                QUESTION ONE -- THE DUNGEON SYSTEM                |");
                Console.WriteLine("|         How many players can join a typical dungeon duty?        |");
                Console.WriteLine(".__________________________________________________________________.");
                Console.WriteLine();
                Console.WriteLine("                            (a): 5 Players.                         ");
                Console.WriteLine("                            (b): 4 Players.                         ");
                Console.WriteLine("                            (c): 8 Players.                         ");
                Console.WriteLine("                            (d): 6 Players.                         ");

                Console.WriteLine("====================================================================");
                questionOneAnswer = Console.ReadLine();
                Console.WriteLine("====================================================================");

                switch (questionOneAnswer)
                {
                    case "a":
                    case "A":
                        // ANSWER A: 5 PLAYERS
                        if (aOneAnswer == false)
                        {
                            questionOneAttempts++;
                            aOneAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|  (a): 5 Players is incorrect. Please press Enter and try again!  |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Loop to keep user within the confirmation until they select a valid response.
                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (a): 5 Players as an incorrect answer. |");
                                Console.WriteLine("|   Are you sure you want to submit the same answer again? Please  |");
                                Console.WriteLine("|                  enter (Y) Yes, or (N) No:                       |");
                                Console.WriteLine(".__________________________________________________________________.");

                                Console.WriteLine("====================================================================");
                                userConfirmation = Console.ReadLine();
                                Console.WriteLine("====================================================================");

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                      Okay! Submitting again. . .                 |");
                                    Console.WriteLine("|  (a): 5 Players is incorrect. Please press Enter and try again!  |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionOneAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "b":
                    case "B":
                        // ANSWER B: 4 PLAYERS
                        questionOneAttempts++;
                        quizContinue = true;
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine($"                    (b): 4 Players is correct!                     ");
                        Console.WriteLine($"                     It took you {questionOneAttempts} attempt(s)! ");
                        Console.WriteLine(".__________________________________________________________________.");

                        switch (questionOneAttempts)
                        {
                            case 1:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question one was 20/20!              |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionOneScore = 20;
                                userScore = userScore + 20;
                                break;

                            case 2:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question one was 10/20!              |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionOneScore = 10;
                                userScore = userScore + 10;
                                break;

                            case 3:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question one was 5/20!               |");
                                Console.WriteLine(".__________________________________________________________________.");
                                questionOneScore = 5;
                                userScore = userScore + 5;
                                break;

                            default:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question one was 0/20!               |");
                                Console.WriteLine(".__________________________________________________________________.");
                                questionOneScore = 0;
                                userScore = userScore + 0;
                                break;
                        }
                        break;

                    case "c":
                    case "C":
                        // ANSWER C: 8 PLAYERS
                        if (cOneAnswer == false)
                        {
                            questionOneAttempts++;
                            cOneAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|  (c): 8 Players is incorrect. Please press Enter and try again!  |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (c): 8 Players as an incorrect answer. |");
                                Console.WriteLine("|   Are you sure you want to submit the same answer again? Please  |");
                                Console.WriteLine("|                  enter (Y) Yes, or (N) No:                       |");
                                Console.WriteLine(".__________________________________________________________________.");
                                userConfirmation = Console.ReadLine();

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                      Okay! Submitting again. . .                 |");
                                    Console.WriteLine("|  (c): 8 Players is incorrect. Please press Enter and try again!  |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionOneAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "d":
                    case "D":
                        // ANSWER D: 6 PLAYERS
                        if (dOneAnswer == false)
                        {
                            questionOneAttempts++;
                            dOneAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|  (d): 6 Players is incorrect. Please press Enter and try again!  |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {
                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (d): 6 Players as an incorrect answer. |");
                                Console.WriteLine("|   Are you sure you want to submit the same answer again? Please  |");
                                Console.WriteLine("|                  enter (Y) Yes, or (N) No:                       |");
                                Console.WriteLine(".__________________________________________________________________.");
                                userConfirmation = Console.ReadLine();

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                      Okay! Submitting again. . .                 |");
                                    Console.WriteLine("|  (d): 6 Players is incorrect. Please press Enter and try again!  |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionOneAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }

                        }
                        break;

                    default:
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                        Console.WriteLine(".__________________________________________________________________.");
                        Console.ReadLine();
                        break;

                }



            }

            // ================================================================================================

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|             Press Enter to continue to question two!             |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.ReadLine();
            Console.Clear();

            // --------------------------
            // QUESTION TWO
            // WHAT IS THE NAME OF THE GROUP THAT THE PLAYER'S CHARACTER IS PART OF?
            // --------------------------
            quizContinue = false;

            while (quizContinue == false)
            {
                confirmationChoice = false;

                Console.WriteLine(".------------------------------------------------------------------.");
                Console.WriteLine("|                QUESTION TWO -- THE STORY                         |");
                Console.WriteLine("|  What is the name of the group that the player's character is    |");
                Console.WriteLine("|                          part of?                                |");
                Console.WriteLine(".__________________________________________________________________.");
                Console.WriteLine();
                Console.WriteLine("                      (a): The Scions of the Seventh Dawn           ");
                Console.WriteLine("                      (b): The Lambs of Dalamud                     ");
                Console.WriteLine("                      (c): The Garlean Empire                       ");
                Console.WriteLine("                      (d): The Students of Baldesion                ");

                Console.WriteLine("====================================================================");
                questionTwoAnswer = Console.ReadLine();
                Console.WriteLine("====================================================================");

                switch (questionTwoAnswer)
                {
                    case "a":
                    case "A":
                        // ANSWER A: THE SCIONS OF THE SEVENTH DAWN
                        questionTwoAttempts++;
                        quizContinue = true;
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine("           (a): Scions of the Seventh Dawn is correct!");
                        Console.WriteLine($"                   It took you {questionTwoAttempts} attempt(s)!");
                        Console.WriteLine(".__________________________________________________________________.");

                        switch (questionTwoAttempts)
                        {
                            case 1:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question two was 20/20!              |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionTwoScore = 20;
                                userScore = userScore + 20;
                                break;

                            case 2:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question two was 10/20!              |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionTwoScore = 10;
                                userScore = userScore + 10;
                                break;

                            case 3:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question two was 5/20!               |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionTwoScore = 5;
                                userScore = userScore + 5;
                                break;

                            default:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question two was 0/20!               |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionTwoScore = 0;
                                userScore = userScore + 0;
                                break;
                        }
                        break;

                    case "b":
                    case "B":
                        // ANSWER B: THE LAMBS OF DALAMUD
                        if (bTwoAnswer == false)
                        {
                            questionTwoAttempts++;
                            bTwoAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|              (b): The Lambs of Dalamud is incorrect.             |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|     You have already chosen (b): The Lambs of Dalamud as an      |");
                                Console.WriteLine("|                        incorrect answer.                         |");
                                Console.WriteLine("|      Are you sure you want to submit the same answer again?      |");
                                Console.WriteLine("|              Please enter (Y) Yes, or (N) No:                    |");
                                Console.WriteLine(".__________________________________________________________________.");

                                Console.WriteLine("====================================================================");
                                userConfirmation = Console.ReadLine();
                                Console.WriteLine("====================================================================");

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                    Okay! Submitting again. . .                   |");
                                    Console.WriteLine("|             (b): The Lambs of Dalamud is incorrect.              |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();

                                    questionTwoAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "c":
                    case "C":
                        // ANSWER C: THE GARLEAN EMPIRE
                        if (cTwoAnswer == false)
                        {
                            questionTwoAttempts++;
                            cTwoAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|               (c): The Garlean Empire is incorrect.              |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|     You have already chosen (c): The Garlean Empire as an        |");
                                Console.WriteLine("|                        incorrect answer.                         |");
                                Console.WriteLine("|      Are you sure you want to submit the same answer again?      |");
                                Console.WriteLine("|              Please enter (Y) Yes, or (N) No:                    |");
                                Console.WriteLine(".__________________________________________________________________.");

                                Console.WriteLine("====================================================================");
                                userConfirmation = Console.ReadLine();
                                Console.WriteLine("====================================================================");

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                    Okay! Submitting again. . .                   |");
                                    Console.WriteLine("|              (c): The Garlean Empire is incorrect.               |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionTwoAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "d":
                    case "D":
                        // ANSWER D: THE STUDENTS OF BALDESION
                        if (dTwoAnswer == false)
                        {
                            questionTwoAttempts++;
                            dTwoAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|            (d): The Students of Baldesion is incorrect.          |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {
                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (d): The Students of Baldesion as an   |");
                                Console.WriteLine("|                        incorrect answer.                         |");
                                Console.WriteLine("|      Are you sure you want to submit the same answer again?      |");
                                Console.WriteLine("|              Please enter (Y) Yes, or (N) No:                    |");
                                Console.WriteLine(".__________________________________________________________________.");

                                Console.WriteLine("====================================================================");
                                userConfirmation = Console.ReadLine();
                                Console.WriteLine("====================================================================");

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                    Okay! Submitting again. . .                   |");
                                    Console.WriteLine("|            (d): The Students of Baldesion is incorrect.          |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionTwoAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }

                        }
                        break;

                    default:
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine("|        Invalid input. Please press Enter and try again.          |");
                        Console.WriteLine(".__________________________________________________________________.");
                        Console.ReadLine();
                        break;

                }



            }

            // ================================================================================================

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|           Press Enter to continue to question three!             |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.ReadLine();
            Console.Clear();

            // --------------------------
            // QUESTION THREE
            // WHICH OF THE FOLLOWING IS NOT A JOB OR CLASS OPTION IN FFXIV?
            // --------------------------

            quizContinue = false;

            while (quizContinue == false)
            {
                confirmationChoice = false;

                Console.WriteLine(".------------------------------------------------------------------.");
                Console.WriteLine("|                QUESTION THREE -- THE PLAYABLE CLASSES            |");
                Console.WriteLine("|  Which of the following is NOT a job or class option in FFXIV?   |");
                Console.WriteLine(".__________________________________________________________________.");
                Console.WriteLine();
                Console.WriteLine("                          (a): Reaper                               ");
                Console.WriteLine("                          (b): Paladin                              ");
                Console.WriteLine("                          (c): Sage                                 ");
                Console.WriteLine("                          (d): Evoker                               ");

                Console.WriteLine("====================================================================");
                questionThreeAnswer = Console.ReadLine();
                Console.WriteLine("====================================================================");

                switch (questionThreeAnswer)
                {
                    case "a":
                    case "A":
                        if (aThreeAnswer == false)
                        {
                            questionThreeAttempts++;
                            aThreeAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|                     (a): Reaper is incorrect.                    |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (a): Reaper as an incorrect answer.    |");
                                Console.WriteLine("|     Are you sure you want to submit the same answer again?       |");
                                Console.WriteLine("|               Please enter (Y) Yes, or (N) No:                   |");
                                Console.WriteLine(".__________________________________________________________________.");
                                userConfirmation = Console.ReadLine();

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                     Okay! Submitting again. . .                  |");
                                    Console.WriteLine("|                     (a): Reaper is incorrect.                    |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionThreeAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "b":
                    case "B":
                        if (bThreeAnswer == false)
                        {
                            questionThreeAttempts++;
                            bThreeAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|                    (b): Paladin is incorrect.                    |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|   You have already chosen (b): Paladin as an incorrect answer.   |");
                                Console.WriteLine("|     Are you sure you want to submit the same answer again?       |");
                                Console.WriteLine("|               Please enter (Y) Yes, or (N) No:                   |");
                                Console.WriteLine(".__________________________________________________________________.");
                                userConfirmation = Console.ReadLine();

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                     Okay! Submitting again. . .                  |");
                                    Console.WriteLine("|                    (b): Paladin is incorrect.                    |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionThreeAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "c":
                    case "C":
                        if (cThreeAnswer == false)
                        {
                            questionThreeAttempts++;
                            cThreeAnswer = true;
                            Console.WriteLine(".------------------------------------------------------------------.");
                            Console.WriteLine("|                     (c): Sage is incorrect.                      |");
                            Console.WriteLine("|                 Please press Enter and try again!                |");
                            Console.WriteLine(".__________________________________________________________________.");
                            Console.ReadLine();
                        }
                        else
                        {

                            while (confirmationChoice == false)
                            {
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|    You have already chosen (c): Sage as an incorrect answer.     |");
                                Console.WriteLine("|     Are you sure you want to submit the same answer again?       |");
                                Console.WriteLine("|               Please enter (Y) Yes, or (N) No:                   |");
                                Console.WriteLine(".__________________________________________________________________.");
                                userConfirmation = Console.ReadLine();

                                if (userConfirmation == "y" || userConfirmation == "Y")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                     Okay! Submitting again. . .                  |");
                                    Console.WriteLine("|                     (c): Sage is incorrect.                      |");
                                    Console.WriteLine("|                Please press Enter and try again!                 |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    questionThreeAttempts++;
                                    confirmationChoice = true;
                                }
                                else if (userConfirmation == "n" || userConfirmation == "N")
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|                            No problem!                           |");
                                    Console.WriteLine("|         Please press Enter and choose a different answer.        |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                    confirmationChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine(".------------------------------------------------------------------.");
                                    Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                                    Console.WriteLine(".__________________________________________________________________.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;

                    case "d":
                    case "D":
                        questionThreeAttempts++;
                        quizContinue = true;
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine("                     (d): Evoker is correct!                        ");
                        Console.WriteLine($"                     It took you {questionThreeAttempts} attempt(s)! ");
                        Console.WriteLine(".__________________________________________________________________.");

                        switch (questionThreeAttempts)
                        {
                            case 1:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question three was 20/20!            |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionThreeScore = 20;
                                userScore = userScore + 20;
                                break;

                            case 2:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question three was 10/20!            |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionThreeScore = 10;
                                userScore = userScore + 10;
                                break;

                            case 3:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question three was 5/20!             |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionThreeScore = 5;
                                userScore = userScore + 5;
                                break;

                            default:
                                Console.WriteLine(".------------------------------------------------------------------.");
                                Console.WriteLine("|              Your score for question three was 0/20!             |");
                                Console.WriteLine(".__________________________________________________________________.");

                                questionThreeScore = 0;
                                userScore = userScore + 0;
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine(".------------------------------------------------------------------.");
                        Console.WriteLine("|         Invalid input. Please press Enter and try again.         |");
                        Console.WriteLine(".__________________________________________________________________.");
                        Console.ReadLine();
                        break;

                }



            }

            // ================================================================================================

            // Round percentage to two decimal places to improve readability.
            percentageScore = Math.Round((userScore / 60) * 100, 2);

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                Press Enter to view the results!                  |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                           SCORE CARD                             |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine($"    FIRST NAME: {firstName}");
            Console.WriteLine($"    LAST NAME:  {lastName}");
            Console.WriteLine($"    FULL NAME:  {fullName}");
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                QUESTION ONE -- THE DUNGEON SYSTEM                |");
            Console.WriteLine("|         How many players can join a typical dungeon duty?        |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine($"    ATTEMPTS: {questionOneAttempts}.");
            Console.WriteLine($"    SCORE:    {questionOneScore} / 20.");
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                QUESTION TWO -- THE STORY                         |");
            Console.WriteLine("|  What is the name of the group that the player's character is    |");
            Console.WriteLine("|                          part of?                                |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine($"    ATTEMPTS: {questionTwoAttempts}.");
            Console.WriteLine($"    SCORE:    {questionTwoScore} / 20.");
            Console.WriteLine(".------------------------------------------------------------------.");
            Console.WriteLine("|                QUESTION THREE -- THE PLAYABLE CLASSES            |");
            Console.WriteLine("|  Which of the following is NOT a job or class option in FFXIV?   |");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine($"    ATTEMPTS: {questionThreeAttempts}.");
            Console.WriteLine($"    SCORE: {questionThreeScore} / 20.");
            Console.WriteLine(".__________________________________________________________________.");
            Console.WriteLine();
            Console.WriteLine($"    FINAL SCORE: {percentageScore}% ({userScore} / 60)");
            Console.WriteLine(".__________________________________________________________________.");
        }
    }
}