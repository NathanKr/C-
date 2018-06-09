<h2>Introduction</h2>
<li>This is a small console game called Pong</li> 
<li>It is a final assignment of a course "Object Orient Programming using C#"</li>
<li>UI here is minimal because the important issue is the business logic using OOP</li>
</ul>

<h2>Preview</h2>
<a href='https://www.youtube.com/watch?v=jnxOArmpBIg'>Preview</a>

<h2>Points of interest</h2>
<ul>
<li>OOP concepts used here</li>
<ol>
<li>Encapsulation</li>
<li>Inheritance - Player class</li>
<li>Abstraction - ICollide interface</li>
<li>Polymorphism - Shape abstract class is inherited by the following classes: 
<ul>
<li>Border</li>
<li>CleanBoard</li>
<li>PlayerAuto</li>
<li>PlayerHuman</li>
<li>Ball</li>
</ul>
</li>
</ol>
<li>Timer handler is configured so it will not overlapped</li>
<li>Use of Shape abstraction and ICollide interface makes the design simple and easy to understand and maintain</li>
</ul>

<h2>Show me some code</h2>
```C#
static void Main(string[] args)
        {
            const int nRows = 20, nCols = 40 , nLevel=20 , nGameEnds = 2;
            Game game = new Game(nRows , nCols , nLevel, nGameEnds);
            game.Start();
        }

void TimerCallback(object state){
            Board board = (Board)state;
            board.HandleLogic(out m_bGameHasFinished);
            if (m_bGameHasFinished){
                showFinalResult();
                turnTimerOff();
            }
            else{
                board.Draw();
                scheduleNextTimerCycle();// --- this will prevent timer callback overlapping
            }
            showCurrentResult();
        }
```



<h2>Who maintains and contributes to the project</h2>
Nathan Krasney : https://il.linkedin.com/in/nathankrasney