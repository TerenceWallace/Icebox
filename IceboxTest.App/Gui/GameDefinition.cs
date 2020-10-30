using Icebox;
using System;
using System.Drawing;
using System.Linq;

namespace IceboxTest.Gui
{
     public class GameDefinition : Simulation
     {
          public GameDefinition()
          {
               simulationDefinition = CreateDefinition();
          }

          private SimulationDefinition CreateDefinition()
          {
               SimulationDefinition definition = new SimulationDefinition();

               // Resources
               SimResource resourceWater = new SimResource();
               resourceWater.id = "Water";

               SimResource resourceGrass = new SimResource();
               resourceGrass.id = "Grass";

               SimResource resourcePeople = new SimResource();
               resourcePeople.id = "People";

               definition.resourceTypes.Add(resourceWater.id, resourceWater);
               definition.resourceTypes.Add(resourceGrass.id, resourceGrass);
               definition.resourceTypes.Add(resourcePeople.id, resourcePeople);

               // Paths
               SimPathType pathRoad = new SimPathType();
               pathRoad.color = Color.White.ToArgb();
               pathRoad.id = "Road";

               definition.pathTypes.Add(pathRoad.id, pathRoad);

               // Segments
               SimSegmentType segmentDirt = new SimSegmentType();
               segmentDirt.color = Color.Brown.ToArgb();
               segmentDirt.id = "Dirt";

               definition.segmentTypes.Add(segmentDirt.id, segmentDirt);

               // Agents
               SimAgentType agentPeople = new SimAgentType();
               agentPeople.color = Color.Yellow.ToArgb();
               agentPeople.speed = 10;
               agentPeople.id = "People";

               SimAgentType agentWorker = new SimAgentType();
               agentWorker.color = Color.Orange.ToArgb();
               agentWorker.speed = 10;
               agentWorker.id = "Worker";

               definition.agentTypes.Add(agentPeople.id, agentPeople);
               definition.agentTypes.Add(agentWorker.id, agentWorker);


               // Units
               SimUnitType unitHome = new SimUnitType();
               unitHome.color = Color.Magenta.ToArgb();
               unitHome.mapRadius = 1;
               unitHome.id = "Home";

               SimUnitType unitWork = new SimUnitType();
               unitWork.color = Color.Cyan.ToArgb();
               unitWork.mapRadius = 3;
               unitWork.id = "Work";


               // Unit Capacities & Resources
               unitHome.caps = new SimResourceBinCollection();
               unitHome.caps.AddResource(resourcePeople, 4);

               unitHome.resources = new SimResourceBinCollection();
               unitHome.resources.AddResource(resourcePeople, 4);
               unitHome.targets = new string[] { "Home" };

               unitWork.caps = new SimResourceBinCollection();
               unitWork.caps.AddResource(resourcePeople, 2);
               unitWork.targets = new string[] { "Work" };

               unitWork.resources = new SimResourceBinCollection();


               // Unit Rules
               // Rule Home
               SimRuleValueLocal valueLocalPeople = new SimRuleValueLocal();
               valueLocalPeople.resource = resourcePeople;

               SimRuleCommandAdd commandAddPeople = new SimRuleCommandAdd();
               commandAddPeople.amount = 1;
               commandAddPeople.target = valueLocalPeople;

               SimRuleCommandRemove commandRemovePeople = new SimRuleCommandRemove();
               commandRemovePeople.amount = 1;
               commandRemovePeople.target = valueLocalPeople;

               SimRuleUnit ruleUnitSendPeopleToWork = new SimRuleUnit();
               ruleUnitSendPeopleToWork.id = "SendPeopleToWork";
               ruleUnitSendPeopleToWork.rate = 20;
               ruleUnitSendPeopleToWork.commands = new SimRuleCommand[] { commandRemovePeople, commandAddPeople };

               unitHome.rules = new SimRuleUnit[] { ruleUnitSendPeopleToWork };

               //  * End Rule Home


               // Rule Work
               // RULE #1
               SimRuleValueMap valueMapUnitWater = new SimRuleValueMap();
               valueMapUnitWater.mapId = "Water";

               SimRuleCommandTest commandTestWater = new SimRuleCommandTest();
               commandTestWater.amount = 100;
               commandTestWater.comparison = SimRuleCommandTest.Comparison.GreaterThanOrEqualTo;
               commandTestWater.target = valueMapUnitWater;

               SimRuleCommandRemove commandRemoveWorker = new SimRuleCommandRemove();
               commandRemoveWorker.amount = 1;
               commandRemoveWorker.target = valueLocalPeople;

               SimRuleCommandAgent commandAddAgent = new SimRuleCommandAgent();
               commandAddAgent.agentType = agentWorker;
               commandAddAgent.resources = new SimResourceBinCollection();
               commandAddAgent.resources.AddResource(resourcePeople, 1);
               commandAddAgent.searchTarget = "Work";

               SimRuleUnit ruleUnitSendPeopleToHome = new SimRuleUnit();
               ruleUnitSendPeopleToHome.id = "SendPeopleToHome";
               ruleUnitSendPeopleToHome.rate = 100;
               ruleUnitSendPeopleToHome.onFail = new MockRuleUnit(unitWork);
               ruleUnitSendPeopleToHome.commands = new SimRuleCommand[] { commandTestWater, commandRemoveWorker, commandAddAgent };
               // END RULE #1

               //RULE #2
               SimRuleCommandTest commandTestPeople = new SimRuleCommandTest();
               commandTestPeople.amount = 1;
               commandTestPeople.comparison = SimRuleCommandTest.Comparison.GreaterThanOrEqualTo;
               commandTestPeople.target = valueLocalPeople;

               SimRuleCommandAdd commandAddPeopleWater = new SimRuleCommandAdd();
               commandAddPeopleWater.amount = 30;
               commandAddPeopleWater.target = valueMapUnitWater;

               SimRuleUnit UsePeopleToWater = new SimRuleUnit();
               UsePeopleToWater.id = "UsePeopleToWater";
               UsePeopleToWater.rate = 5;
               UsePeopleToWater.commands = new SimRuleCommand[] { commandTestPeople, commandAddPeopleWater };

               unitWork.rules = new SimRuleUnit[] { ruleUnitSendPeopleToHome, UsePeopleToWater };

               // END RULE #2
               // * End Rule Work

               definition.unitTypes.Add(unitHome.id, unitHome);
               definition.unitTypes.Add(unitWork.id, unitWork);

               //Add 2 of water every 10 ticks
               SimRuleValueMap valueMapWater = new SimRuleValueMap();
               valueMapWater.mapId = "Water";

               SimRuleCommandAdd commandAddWater = new SimRuleCommandAdd();
               commandAddWater.amount = 2;
               commandAddWater.target = valueMapWater;

               SimRuleMap ruleMapAddWater = new SimRuleMap();
               ruleMapAddWater.id = "AddWater";
               ruleMapAddWater.rate = 10;
               ruleMapAddWater.randomTiles = true;
               ruleMapAddWater.randomTilesPercent = 25;
               ruleMapAddWater.commands = new SimRuleCommand[] { commandAddWater };

               //Water Map
               SimMapType mapTypeWater = new SimMapType();
               mapTypeWater.id = "Water";
               mapTypeWater.color = Color.AliceBlue.ToArgb();
               mapTypeWater.capacity = 100;
               mapTypeWater.rules = new SimRuleMap[] { ruleMapAddWater };

               definition.mapTypes.Add(mapTypeWater.id, mapTypeWater);

               //Add grass every 7 ticks if there is 10 of water available
               SimRuleValueMap valueMapGrass = new SimRuleValueMap();
               valueMapGrass.mapId = "Grass";

               SimRuleCommandRemove commandRemoveWater = new SimRuleCommandRemove();
               commandRemoveWater.amount = 10;
               commandRemoveWater.target = valueMapWater;

               SimRuleCommandAdd commandAddGrass = new SimRuleCommandAdd();
               commandAddGrass.amount = 1;
               commandAddGrass.target = valueMapGrass;

               SimRuleMap ruleMapCreateGrass = new SimRuleMap();
               ruleMapCreateGrass.id = "CreateGrass";
               ruleMapCreateGrass.rate = 7;
               ruleMapCreateGrass.commands = new SimRuleCommand[] { commandRemoveWater, commandAddGrass };

               //Grass Map
               SimMapType mapTypeGrass = new SimMapType();
               mapTypeGrass.id = "Grass";
               mapTypeGrass.color = Color.Black.ToArgb();
               mapTypeGrass.capacity = 10;
               mapTypeGrass.rules = new SimRuleMap[] { ruleMapCreateGrass };

               definition.mapTypes.Add(mapTypeGrass.id, mapTypeGrass);

               return definition;
          }

          public class MockRuleUnit : SimRuleUnit
          {

               public MockRuleUnit(SimUnitType type) : base()
               {
               }

               public override bool Execute(SimRuleContext context)
               {
                    return false;
               }
          }

     }

}
