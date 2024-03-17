namespace CredImmo.App
{
    public sealed class ArgumentParser
    {
        private string[] args;

        public ArgumentParser(string[] args)
        {
            if(args.Length < 3)
                throw new ArgumentException("Le nombre d'arguments doit être égal à 3");
            this.args = args;
        }
    }
}
