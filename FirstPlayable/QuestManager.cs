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

        public QuestManager(Player player,HUD hud)
        {
            this.player = player;
            this.hud = hud;
            activeQuests = new List<Quest>();
            completedQuests = new List<Quest>();
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
                activeQuests.Add(quest);
                quest.Complete(hud);    
            }
        }
    }
}
