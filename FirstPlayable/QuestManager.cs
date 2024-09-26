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
        public QuestManager(Player player,HUD hud)
        {
            this.player = player;
            this.hud = hud;
            activeQuests = new List<Quest>();
            completedQuests = new List<Quest>();
            numofKills = 5;
        }
        public void Init()
        {
            QuestKillEnemies questKillEnemies = new QuestKillEnemies(numofKills,player);
            QuestCollectItems questCollectItems = new QuestCollectItems(30,player);
            FinalQuest finalQuest = new FinalQuest();
            AddQuest(questKillEnemies);
            AddQuest(questCollectItems);
            AddQuest(finalQuest);
        }
        public void Update()
        {
            CheckQuestProgress();
        }
        public void AddQuest(Quest quest)
        { 
            activeQuests.Add(quest);
            quest.Started(hud);
        }
        public void CompleteQuest(Quest quest)
        {
            if(activeQuests.Contains(quest))
            {
                activeQuests.Remove(quest);
                completedQuests.Add(quest);
                quest.Complete(hud,player);  
            }
        }
        public void CheckQuestProgress()
        {
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
                CompleteQuest(quest);
            }
        }

        public List<Quest> GetActiveQuests()
        {
            return activeQuests;
        }
    }
}
