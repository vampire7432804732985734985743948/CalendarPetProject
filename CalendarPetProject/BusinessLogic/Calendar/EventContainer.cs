namespace CalendarPetProject.BusinessLogic.Calendar
{
    public class EventContainer
    {

        public string TaskTitle{ get; private set; } = string.Empty;
        public string TaskDescription { get; private set; } = string.Empty;

        public void AddDayTaskDescription(string taskDescription)
        {
            if (!string.IsNullOrWhiteSpace(taskDescription))
            { 
                TaskDescription = taskDescription;
            }
        }
        public void AddDayTaskTitle(string taskTitle)
        {
            if (!string.IsNullOrWhiteSpace(taskTitle))
            { 
                TaskTitle = taskTitle;
            }
        }
    }
}
