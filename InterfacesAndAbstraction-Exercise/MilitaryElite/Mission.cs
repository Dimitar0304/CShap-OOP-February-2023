using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public string State { get; set; }

        public void CompleteMission()
        {
            this.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}