namespace advent;
public class Day2
{
    private readonly string _input;
    private readonly List<(Move, Move)> _roundsMoveMove = new();
    private readonly List<(Move, Move)> _roundsMoveResult = new();

    public enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public Day2(string input)
    {
        _input = input;
        var rounds = _input.Split(Environment.NewLine);
        foreach (var round in rounds)
        {
            if (string.IsNullOrWhiteSpace(round))
            {
                continue;
            }
            var roundFromInput = GetRoundFromInputMoveMove(round);
            _roundsMoveMove.Add(roundFromInput);

            roundFromInput = GetRoundFromInputMoveResult(round);
            _roundsMoveResult.Add(roundFromInput);
        }
    }

    public int GetTotalScoreMoveMove()
    {
        var totalScore = 0;
        foreach (var round in _roundsMoveMove)
        {
            var score = GetScoreForRound(round.Item1, round.Item2);
            totalScore += score;
        }
        return totalScore;
    }

    public int GetTotalScoreMoveResult()
    {
        var totalScore = 0;
        foreach (var round in _roundsMoveResult)
        {
            var score = GetScoreForRound(round.Item1, round.Item2);
            totalScore += score;
        }
        return totalScore;
    }

    public (Move, Move) GetRoundFromInputMoveMove(string round)
    {
        var moves = round.Split(" ");
        var opponentMove = GetOpponentMoveFromInput2(moves[0]);
        var myMove = GetMyMoveFromInput2(moves[1]);
        return (myMove, opponentMove);
    }

    public (Move, Move) GetRoundFromInputMoveResult(string round)
    {
        var moves = round.Split(" ");
        var opponentMove = GetOpponentMoveFromInput2(moves[0]);
        var result = GetResultFromInput(moves[1]);
        var myMove = GetMoveFromResult(opponentMove, result);
        return (myMove, opponentMove);
    }

    public Move GetOpponentMoveFromInput2(string move)
    {
        // A for Rock, B for Paper, and C for Scissors
        return move switch
        {
            "A" => Move.Rock,
            "B" => Move.Paper,
            "C" => Move.Scissors,
            _ => throw new ArgumentOutOfRangeException(move)
        };
    }

    // X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win
    public bool? GetResultFromInput(string result)
    {
        return result switch
        {
            "X" => false,
            "Y" => null,
            "Z" => true,
            _ => throw new ArgumentOutOfRangeException(result)
        };
    }

    public Move GetWinningMove(Move move)
    {
        return move switch
        {
            Move.Rock => Move.Paper,
            Move.Paper => Move.Scissors,
            Move.Scissors => Move.Rock,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }

    public Move GetLosingMove(Move move)
    {
        return move switch
        {
            Move.Rock => Move.Scissors,
            Move.Paper => Move.Rock,
            Move.Scissors => Move.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }

    public Move GetMoveFromResult(Move move, bool? result)
    {
        if (result == null)
        {
            return move;
        }

        return result.Value ? GetWinningMove(move) : GetLosingMove(move);
    }

    public Move GetMyMoveFromInput2(string move)
    {
        // X for Rock, Y for Paper, and Z for Scissors
        return move switch
        {
            "X" => Move.Rock,
            "Y" => Move.Paper,
            "Z" => Move.Scissors,
            _ => throw new ArgumentOutOfRangeException(move)
        };
    }

    public int GetScoreForRound(Move myMove, Move opponentMove)
    {
        // The score for a single round is the score for the shape you selected 
        // (1 for Rock, 2 for Paper, and 3 for Scissors) 
        // plus the score for the outcome of the round 
        // (0 if you lost, 3 if the round was a draw, and 6 if you won).
        var result = Won(myMove, opponentMove);
        var moveScore = GetScoreForMove(myMove);
        var resultScore = GetScoreForResult(result);
        var totalScore = moveScore + resultScore;
        return totalScore;
    }

    public int GetScoreForResult(bool? result)
    {
        // (0 if you lost, 3 if the round was a draw, and 6 if you won).
        if (result == null)
        {
            return 3;
        }

        return result.Value ? 6 : 0;
    }

    public int GetScoreForMove(Move move)
    {
        // (1 for Rock, 2 for Paper, and 3 for Scissors) 
        return move switch
        {
            Move.Rock => 1,
            Move.Paper => 2,
            Move.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }

    public bool? Won(Move myMove, Move opponentMove)
    {
        if (myMove == opponentMove)
        {
            return null;
        }

        if (myMove == Move.Rock && opponentMove == Move.Scissors)
        {
            return true;
        }

        if (myMove == Move.Paper && opponentMove == Move.Rock)
        {
            return true;
        }

        if (myMove == Move.Scissors && opponentMove == Move.Paper)
        {
            return true;
        }

        return false;
    }
}
