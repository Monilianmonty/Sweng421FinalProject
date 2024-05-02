using System.Diagnostics;
using System.Reflection;

namespace Sweng421FinalProject
{

    public class TMS
    {
        public ITaskScheduler scheduler;
        public TaskVisitorIF tvif;

        public void addTask(String task, int priority, DateTime deadline)
        {

        }

        public void removeTask(Task task)
        {

        }

        public void editTask(Task task)
        {

        }

        public void createReport(TaskVisitorIF tvif)
        {

        }

        public void AddMember(OrganizationIF2 member)
        {

        }
    }

    public interface ITaskScheduler
    {
        public void rescheduleTask(Task t, DateTime deadline);
    }

    public class TaskScheduler : ITaskScheduler
    {
        public void rescheduleTask(Task t, DateTime deadline)
        {

        }
    }


    public class User
    {
        //public MainGUI mg;
        public TMS tms;
    }


    public interface TaskIF
    {
        public String getTask();

        public void setTask(String task);

        public int getPriority();

        public void setPriority(int priority);

        public DateTime getDeadline();

        public void setDeadline(DateTime deadline);

    }

    public abstract class AbstractTask : TaskIF
    {
        String task;
        int priority;
        DateTime deadline;

        public AbstractTask()
        {

        }
        public String getTask()
        {
            return task;
        }

        public void setTask(String task)
        {
            this.task = task;
        }

        public int getPriority()
        {
            return this.priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public abstract void presentTask();

        public DateTime getDeadline()
        {
            return deadline;
        }

        public void setDeadline(DateTime deadline)
        {
            this.deadline = deadline;
        }
    }

    public class LowPriorityTask : AbstractTask
    {
        String task;

        int priority = 3;

        DateTime deadline;

        public LowPriorityTask(String task, int priority, DateTime deadline)
        {
            this.task = task;
            this.priority = priority;
            this.deadline = deadline;

        }

        public String getTask()
        {
            return task;
        }

        public void setTask(String task)
        {
            this.task = task;
        }

        public int getPriority()
        {
            return this.priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public override void presentTask()
        {
            Console.WriteLine("this task is low priority with the task being " + task + " and the deadline is " + deadline);
        }



    }
    public class TaskVisitor : TaskVisitorIF
    {
        public void visit(Task AbstractTask)
        {

        }
    }

    public interface TaskVisitorIF
    {
        public void visit(Task AbstractTask)
        {

        }
    }

    public class MediumPriorityTask : AbstractTask
    {
        String task;

        int priority = 2;

        DateTime deadline;

        public MediumPriorityTask(String task, int priority, DateTime deadline)
        {
            this.task = task;
            this.priority = priority;
            this.deadline = deadline;

        }

        public MediumPriorityTask() { }

        public String getTask()
        {
            return task;
        }

        public void setTask(String task)
        {
            this.task = task;
        }

        public int getPriority()
        {
            return this.priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public override void presentTask()
        {
            Console.WriteLine("this task is medium priority with the task being " + task + " and the deadline is " + deadline);
        }


    }

    public class HighPriorityTask : AbstractTask
    {
        String task;

        int priority = 2;

        DateTime deadline;

        public HighPriorityTask(String task, int priority, DateTime deadline)
        {
            this.task = task;
            this.priority = priority;
            this.deadline = deadline;

        }

        public String getTask()
        {
            return task;
        }

        public void setTask(String task)
        {
            this.task = task;
        }

        public int getPriority()
        {
            return this.priority;
        }

        public void setPriority(int priority)
        {
            this.priority = priority;
        }

        public override void presentTask()
        {
            Console.WriteLine("this task is high priority with the task being " + task + " and the deadline is " + deadline);
        }
    }

    public class NotificationWrapper
    {
        public TaskIF tif;
        public NotificationSystem ns;


    }

    public class AbstractTaskNotificationWrapper
    {
        public String getTask()
        {
            return null;
        }

        public void setTask(String task)
        {
        }

        public int getpriority()
        {
            return 0;
        }

        public void setPriority(int priority)
        {

        }

        public void notify()
        {

        }
    }

    public class NotificationSystem
    {
        public void notify()
        {

        }
    }

    public class DeadlineNotification : NotificationSystem
    {
        public void notify()
        {

        }
    }

    public class StatusUpdate : NotificationSystem
    {
        public void notify()
        {

        }
    }


    public interface TaskFactoryIF
    {

        public  TaskIF createTask(String name, String task, int priority, DateTime deadline);
    }

    public class TaskFactory : TaskFactoryIF
    {
        public TaskIF createTask(string name, string task, int priority, DateTime deadline)
        {
            Type moduleType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (moduleType == null)
            {
                Console.WriteLine($"Module type does not exist: {name}");
                return null; // failure to create module
            }

            //get constructor
            ConstructorInfo constructor = moduleType.GetConstructor(new[] { typeof(string), typeof(int), typeof(DateTime) });
            if (constructor == null)
            {
                Console.WriteLine($"No suitable constructor found for {name}");
                return null;
            }

            try
            {
                AbstractTask moduleInstance = (AbstractTask)constructor.Invoke(new object[] { task, priority, deadline });
                Console.WriteLine($"Created instance of {moduleType.Name}");
                return moduleInstance;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating instance: {ex.Message}");
                return null;
            }
        }
    }

    public class Organization : OrganizationIF2
    {
        private OrganizationIF2[] oif2;
    }

    public interface OrganizationIF2
    {

    }

    public abstract class AbstractOrganization : OrganizationIF2
    {
        public abstract String getName();

        public String GetTask()
        {
            return "";
        
        }
    }

        public abstract class CompositePriorityPerson
        {
            String username;
            String password;

            public List<TaskFactoryIF> tasks;
            public TaskVisitorIF tvif;
            public AbstractTaskNotificationWrapper atnw;

            public List<Task> getAllTasks(TMS tms)
            {
                return null;
            }
        }

        public class HighPriorityPerson : CompositePriorityPerson
        {
            String username;
            String password;

            public List<TaskFactoryIF> tasks;
            public TaskVisitorIF tvif;
            public AbstractTaskNotificationWrapper atnw;

            public List<Task> getAllTasks(TMS tms)
            {
                return null;
            }

            public void NotifyLowPriorityPreson(LowPriorityPerson person)
            {

            }
        }

        public class LowPriorityPerson : CompositePriorityPerson
        {
            String username;
            String password;

            public List<TaskFactoryIF> tasks;
            public TaskVisitorIF tvif;
            public AbstractTaskNotificationWrapper atnw;

            public String getName()
            {
                return null;
            }

            public String getTask()
            {
                return null;
            }
        }


        internal static class Program
        {


            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
        static void Main()
        {
            Console.WriteLine("hello");
            string mediumTask = "MediumPriorityTask";

            TaskFactoryIF tfif = new TaskFactory();
            DateTime dateTime = DateTime.Now.AddDays(1); // setting a future deadline

            MediumPriorityTask task = (MediumPriorityTask)tfif.createTask(mediumTask, "Complete an easy task", 2, dateTime);
            if (task != null)
            {
                task.presentTask(); // assuming there's a method to perform the task
            }
            else
            {
                Console.WriteLine("Failed to create task instance.");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }


    }
