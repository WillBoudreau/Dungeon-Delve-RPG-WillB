using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable
{
    internal class QuestManager
    {
        private Player player;
        private HUD hud;
        private List<Quest> activeQuests;
        private List<Quest> completedQuests;
        public int numofKills;
        private int numofItems;
        public QuestManager(Player player,HUD hud)
        {
            this.player = player;
            this.hud = hud;
            activeQuests = new List<Quest>();
            completedQuests = new List<Quest>();
            numofKills = 5;
            numofItems = 15;
        }
        public void Init()
        {
            //Initializes the quests
            QuestKillEnemies questKillEnemies = new QuestKillEnemies(numofKills,player);
            QuestCollectItems questCollectItems = new QuestCollectItems(numofItems,player);
            FinalQuest finalQuest = new FinalQuest();
            AddQuest(questKillEnemies);
            AddQuest(questCollectItems);
            AddQuest(finalQuest);
        }
        public void Update()
        {
            //Checks the progress of the quests
            CheckQuestProgress();
        }
        public void AddQuest(Quest quest)
        {
            //Adds a quest to the active quests
            activeQuests.Add(quest);
            quest.Started(hud);
        }
        public void CompleteQuest(Quest quest)
        {
            //Completes a quest
            if(activeQuests.Contains(quest))
            {
                activeQuests.Remove(quest);
                completedQuests.Add(quest);
                quest.Complete(hud,player);  
            }

        }
        public void CheckQuestProgress()
        {
            //Checks the progress of the quests
            List<Quest> questsToComplete = new List<Quest>();
            foreach(Quest quest in activeQuests)
            {
                if(quest is  QuestKillEnemies killQuest)
                {
                    if(player.KillCount >= killQuest.enemiesToKill)
                    { 
                            questsToComplete.Add(killQuest);
                    }
                }
                else if(quest is QuestCollectItems collectQuest)
                {
                    if(player.currentSeeds >= collectQuest.itemsToCollect)
                    {
                        questsToComplete.Add(collectQuest);
                    }
                }
            }
            foreach(Quest quest in questsToComplete)
            {
                //Completes the quests
                CompleteQuest(quest);
            }
        }

        public List<Quest> GetActiveQuests()
        {
            //Returns the active quests
            return activeQuests;
        }
    }
}
