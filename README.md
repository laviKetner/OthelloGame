# OthelloGame / Reversi
Write in C# using winform interface.

## The Rules:
Othello is a strategy board game for two players, played on an board. There are pieces called disks (often just pieces), which are light on one side and dark on the other. Players take turns placing piece on the board with their assigned color facing up. During a play, any piece of the opponent's color that are in a straight line and bounded by the piece just placed and another piece of the current player's color are turned over to the current player's color.
The target of the game is to have the majority of disks/pieces turned to display your color when the last playable empty square is filled.

## Play mode:
* Human VS Human - Two players
* Human VS AI    - Single player
* Online         - Play against human online

## Load / Save game:
If you want to exit the game during the play, the application will ask you if you want to save the game.
In the first window the user see, he can choose to load the game he save.
The app uses xml file to save the game status.
The files are saved as .otlo type, and the game can loaded only this type of file. 

## AI
If you choose the Single Play mode, you will ask to choose the difficulty of the game:
* **Easy** - The AI will choose the step that will be turned on the least of rival pieces. In addition, if he has the option not to choose a corner, he will take it.
* **Medium** - The AI will choose the step that will be turned on the most of rival pieces.
* **Hard** - The AI give a score to each possible move he has and choose the move that gives a higher score.  

## Online

## Architecture:

**Classes:**

| Class  | Details |
| ------------- | ------------- |
| Coordinate  | Represents a point on the game board  |
| Piece  | Represents a player's disk/piece  |
| Player  | Represents a player (each game has only two players) |
| GamePanel  | Represents the logical board  |
| OtheloGameLogic  | Responsible for the logic of the game (who the next turn is, what legal moves each player has...) When playing against the computer this class responsible for the AI  |
| FormOthloGameBoard  | Represents the UI board  |
| OtheloGameManager  | responsible for connection between the logic game (OtheloGameLogic) and the UI (FormOthloGameBoard)  |
| PiecesPictureBox  | Represent Cell on UI board  |
| FormOpeningLogo  | The logo of the game  |
| FormGameSettings  | The first form the user see, in this form the user choose the setting of the game  |
| FormSinglePlayer  | In this form the user choose the difficulty of the AI and the size of the board he want (6x6, 8x8, 10x10)  |
| FormTwoPlayers  | In this form the user choose only the board he want (6x6, 8x8, 10x10)  |
| FormPlayOnline  | ------  |
| Program  | Containe the Main func and start the game  |



