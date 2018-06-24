using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Backend;

namespace Assets.JsonObjects
{
    public class TroopAmount
    {
        public ArmyType armyId { get; set; }
        public int troopAmount { get; set; }

        public TroopAmount(ArmyType armyId, int troopAmount)
        {
            this.armyId = armyId;
            this.troopAmount = troopAmount;
        }
    }

    public class MoveArmyJson
    {
        public List<TroopAmount> troopAmount { get; set; }
        public int targetTownId { get; set; }
        public int townId { get; set; }
        public string token { get; set; }

        public MoveArmyJson(List<TroopAmount> troopAmount, int targetTownId, int sourceTownId, string token)
        {
            this.troopAmount = troopAmount;
            this.targetTownId = townId;
            this.targetTownId = targetTownId;
            this.townId = sourceTownId;
            this.token = token;
        }
    }
}
