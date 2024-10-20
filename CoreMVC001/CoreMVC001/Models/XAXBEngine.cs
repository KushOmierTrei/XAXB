namespace CoreMVC001.Models
{
    public class XAXBEngine
    {
        public string Secret { get; private set; }
        public string Guess { get; private set; }
        public string Result { get; private set; }

        public XAXBEngine()
        {
            // TODO 0 - randomly 
            string randomSecret = "1234";
            //
            this.Secret = randomSecret;
            this.Guess = null;
            this.Result = null;
        }

        public XAXBEngine(string secretNumber)
        {
            this.Secret = secretNumber;
            this.Guess = null;
            this.Result = null;
        }
        //
        public int numOfA(string guessNumber)
        {
            // TODO 1
            return 0;
        }
        //
        public int numOfB(string guessNumber)
        {
            // TODO 2
            return 0;
        }
        //
        public bool IsGameOver(string guessNumber)
        {
            // TODO 3
            return false;
        }

    }

}
