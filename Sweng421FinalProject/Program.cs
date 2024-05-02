using Sweng421FinalProject;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Sweng421FinalProject
{
    [Serializable]
    public class FileManager
    {
        private string filePath = "people.xml";

        public void SavePerson(PersonBase person)
        {
            List<PersonBase> people = LoadPeople();
            people.Add(person);
            XmlSerializer serializer = new XmlSerializer(typeof(List<PersonBase>), new[] { typeof(User), typeof(Admin) });

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, people);
            }
        }

        public List<PersonBase> LoadPeople()
        {
            Console.WriteLine("Loading data from file: " + Path.GetFullPath(filePath));

            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                return new List<PersonBase>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<PersonBase>), new[] { typeof(User), typeof(Admin) });
            using (var stream = File.OpenRead(filePath))
            {
                return (List<PersonBase>)serializer.Deserialize(stream) ?? new List<PersonBase>();
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            var people = LoadPeople();
            return people.Any(person => person.Username == username && person.Password == password);
        }
    }

    public class XmlSerializerSettings
    {
        public Type[] KnownTypes { get; set; }

        public XmlSerializerSettings()
        {
            // Add all known subclasses of PersonIF that you plan to serialize/deserialize
            KnownTypes = new Type[] { typeof(User), typeof(Admin) };
        }
    }
    public class UserManager
    {
        private List<PersonBase> people;
        private FileManager fileManager = new FileManager();

        public UserManager()
        {
            people = fileManager.LoadPeople();
        }

        public bool AddPerson(PersonBase person)
        {
            if (people.All(p => p.Username != person.Username))
            {
                fileManager.SavePerson(person);  // Save individual person
                people.Add(person);  // Update local cache
                return true;
            }
            return false;
        }

        public PersonBase GetPerson(string username)
        {
            return people.FirstOrDefault(p => p.Username == username);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return fileManager.AuthenticateUser(username, password);
        }
    }
    public class TMS
    {
       

        // public ITaskScheduler scheduler;
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

    public class ServerConnection
    {
        public List<TaskIF> getTasks()
        {
            return null;
        }

        public void updateTasks()
        {

        }
    }

    [Serializable]
    public abstract class PersonBase : PersonIF
    {
        public string Username { get; set; }
        public string Password { get; set; }

        protected PersonBase() { }

        protected PersonBase(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public abstract AbstractTask getInfo();  // Ensure this is an abstract method to be implemented by subclasses
    }

    public interface PersonIF
    {
        string Username { get; set; }
        string Password { get; set; }
        AbstractTask getInfo();
    }
    [Serializable]
    public class User : PersonBase
    {
        [XmlIgnore] // Tasks cannot be serialized directly because TaskIF is an interface
        public List<TaskIF> Tasks { get; private set; }

        public User(string username, string password) : base(username, password)
        {
            Tasks = new List<TaskIF>();
        }

        public User() : base()
        {
            Tasks = new List<TaskIF>();
        }

        public override AbstractTask getInfo()
        {
            // Assuming you return the first task for simplicity; adjust logic as needed
            return Tasks.OfType<AbstractTask>().FirstOrDefault();
        }

        public TaskIF GetTaskByName(string taskName)
        {
            return Tasks.FirstOrDefault(t => t.Task == taskName);
        }

        public void AddTask(TaskIF task)
        {
            if (task != null)
            {
                Tasks.Add(task);
            }
        }
    }


    [Serializable]
    public class Admin : PersonBase
    {
        public List<AbstractTask> tasks = new List<AbstractTask>();

        private UserManager userManager;

        public string Username { get; set; }
        public string Password { get; set; }
        public Admin(string u, string p): base(u,p)
        {
            this.Username = u;
            this.Password = p;
            tasks = new List<AbstractTask>();
        }

       
        public Admin(): base()
        {
            tasks = new List<AbstractTask>();  // Initialize any collections to prevent null reference issues
        }

        public override AbstractTask getInfo()
        {
            foreach (AbstractTask task in tasks)
            {
                if (task is LowPriorityPerson)
                {
                    task.PresentTask();
                    return task;
                }
                else if (task is MediumPriorityTask)
                {
                    task.PresentTask();
                    return task;
                }
                else if (task is HighPriorityTask)
                {
                    task.PresentTask();
                    return task;
                }
            }

            
            return null; 
        }

        //can view user info
        public void viewInfo(string empname, string task, int priority, DateTime deadline)
        {
            AbstractTask at;
            PersonIF u = userManager.GetPerson(empname);
            at = u.getInfo();

           
            

            Console.WriteLine(at);
        }

    }


   
    public interface TaskIF
    {
        string Task { get; }
        int Priority { get;  }
        DateTime Deadline { get;  }
    }
    [Serializable]
    public abstract class AbstractTask : TaskIF
    {
        public string Task { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }

        public abstract void PresentTask();
    }
    
    public class LowPriorityTask : AbstractTask
    {
        public LowPriorityTask(string task, int priority, DateTime deadline)
        {
            Task = task;
            Priority = priority;
            Deadline = deadline;
        }

        public override void PresentTask()
        {
            Console.WriteLine($"This task is low priority with the task being {Task} and the deadline is {Deadline}.");
        }
    }
    
    public class MediumPriorityTask : AbstractTask
    {
        public MediumPriorityTask(string task, int priority, DateTime deadline)
        {
            Task = task;
            Priority = priority;
            Deadline = deadline;
        }

        public override void PresentTask()
        {
            Console.WriteLine($"This task is medium priority with the task being {Task} and the deadline is {Deadline}.");
        }
    }
   
    public class HighPriorityTask : AbstractTask
    {
        public HighPriorityTask(string task, int priority, DateTime deadline)
        {
            Task = task;
            Priority = priority;
            Deadline = deadline;
        }

        public override void PresentTask()
        {
            Console.WriteLine($"This task is high priority with the task being {Task} and the deadline is {Deadline}.");
        }
    }

    public class TaskVisitor : TaskVisitorIF
    {
        List<AbstractTask> tasks = new List<AbstractTask>();


        string report;

        public TaskVisitor(string r)
        {
            this.report = r;

        }

        public void visit(AbstractTask at)
        {
            tasks.Add(at);
        }

        //create report
        public void createReport()
        {
            foreach (AbstractTask task in tasks)
            {
                if (task is LowPriorityTask lowPriorityTask)
                {
                   
                    Console.WriteLine("******** " + report + " *********");
                    lowPriorityTask.PresentTask(); 
                }
                else if (task is MediumPriorityTask mediumprioritytask)
                {

                    Console.WriteLine("******** " + report + " *********");
                    mediumprioritytask.PresentTask();
                }
                else if (task is HighPriorityTask highpriorityperson)
                {

                    Console.WriteLine("******** " + report + " *********");
                    highpriorityperson.PresentTask();
                }
            }
        }



    }

    public interface TaskVisitorIF
    {
    public void visit(AbstractTask a);




    public void createReport();
    }

    
    

    

    public abstract class NotificationSystemWrapper
    {

        
        public abstract void notify();
        

        
    }

    public class DeadlineNotificationWrapper : NotificationSystemWrapper
    {
        public AbstractTask dt;
        public DeadlineNotificationWrapper(AbstractTask t)
        {

            dt = t;
        }
        public override void notify()
        {
            TimeSpan difference = DateTime.Now - dt.Deadline;
            

            Console.WriteLine(difference.Milliseconds + " prio "+ dt.Priority);
        }
    }

    public class StatusUpdateWrapper : NotificationSystemWrapper
    {
        public AbstractTask st;

        public StatusUpdateWrapper(AbstractTask t)
        {
            st = t;

        }
        public override void notify()
        {
            int f = st.Priority;

            Console.WriteLine("Status update on task statement " + st.Task + "with a priority of " + f);

        }
    }


    public interface TaskFactoryIF
    {

        public TaskIF createTask(String name, String task, int priority, DateTime deadline);
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
       // public AbstractTaskNotificationWrapper atnw;

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
       // public AbstractTaskNotificationWrapper atnw;

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
      //  public AbstractTaskNotificationWrapper atnw;

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
            //test factory
            string lowTask = "LowPriorityTask";
            string mediumTask = "MediumPriorityTask";
            string highTask = "HighPriorityTask";

            TaskFactoryIF tfif = new TaskFactory();
            DateTime dateTime = DateTime.Now.AddDays(1); // setting a future deadline

            AbstractTask task = (AbstractTask)tfif.createTask(mediumTask, "Complete an medium task", 2, dateTime);
            AbstractTask t2 = (AbstractTask)tfif.createTask(lowTask, "Complete an low task", 3, dateTime);
            AbstractTask t3 = (AbstractTask)tfif.createTask(highTask, "Complete an high task", 1, dateTime);
            AbstractTask t4 = (AbstractTask)tfif.createTask(highTask, "Complete an high task AGAIIIIIIN", 1, dateTime);

            TaskIF t5 = tfif.createTask(highTask, "Complete an high task AGAIIIIIIN", 1, dateTime);

            if (task != null)
            {
                task.PresentTask(); // assuming there's a method to perform the task
            }
            else
            {
                Console.WriteLine("Failed to create task instance.");
            }

            string report = "report from the boss";

            //test visitor
            TaskVisitorIF tvif = new TaskVisitor(report);

            tvif.visit(task);
            tvif.visit(t2);
            tvif.visit(t3);
            tvif.visit(t4);

            tvif.createReport();
            
            //test wrapper
            NotificationSystemWrapper nsw = new DeadlineNotificationWrapper(task);

            nsw.notify();

            NotificationSystemWrapper dsw = new StatusUpdateWrapper(t2);

            dsw.notify();

            //test users and admins
            Admin a1 = new Admin("admin", "pass");
            User u = new User("user1", "pass");
            User u2 = new User("user2", "pass");
            User u3 = new User("user3", "pass");





            u.AddTask(t5);



            
         

            UserManager um = new UserManager();

            //um.AddPerson(u);
            //um.AddPerson(u2);

            //PersonIF jj = um.GetPerson("user2");

            

           // Console.WriteLine(user);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

   



}