using System.Diagnostics;
using System.Reflection;
using Sweng421FinalProject;

namespace Sweng421FinalProject
{
    static void Main(String[] args)
    {
        Sweng421FinalProject f = new Sweng421FinalProject();

        f = new TaskIF();

        f = new LowPriorityTask()

       
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

    public class ServersideTasks
    {
        private List<TaskIF> tasks;
        private ReadWriteLock lockManager = new ReadWriteLock();
        //...
        public List<TaskIF> getTasks() throws InterruptedException
        {
            lockManager.readLock();
            List<TaskIF> tasks = this.tasks;
        lockManager.done();
          return tasks;
     } // getBid()

    public void updateTasks(List<TaskIF> tasks) throws InterruptedException
    {
        lockManager.writeLock();
          if (tasks != this.tasks) {
            this.tasks = tasks;
        } // if
        lockManager.done();
    } // setBid(int)
} // class Bid
  /public class ReadWriteLock
{
        private int waitingForReadLock = 0;
        private int outstandingReadLocks = 0;

        // The thread that has the write lock or null.
        private Thread writeLockedThread;

        private ArrayList waitingForWriteLock = new ArrayList();

        synchronized public void readLock() throws InterruptedException
        {
          if  (writeLockedThread != null) {
               waitingForReadLock++;
               while (writeLockedThread != null) {
                    wait();
} // while
    waitingForReadLock--;
          } // if
outstandingReadLocks++;
     } // readLock()

    public void writeLock() throws InterruptedException
    {
    Thread thisThread;
    synchronized (this) {
        if (writeLockedThread == null && outstandingReadLocks == 0)
        {
            writeLockedThread = Thread.currentThread();
            return;
        } // if
        thisThread = Thread.currentThread();
        waitingForWriteLock.add(thisThread);
    } // synchronized(this)
    synchronized (thisThread) {
        while (thisThread != writeLockedThread)
        {
            thisThread.wait();
        } // while
    } // synchronized (thisThread)
    synchronized (this) {
        waitingForWriteLock.remove(thisThread);
    } // synchronized (this)
} // writeLock

synchronized public void done()
{
    if (outstandingReadLocks > 0)
    {
        outstandingReadLocks--;
        if (outstandingReadLocks == 0
              && waitingForWriteLock.size() > 0)
        {
            writeLockedThread = (Thread)waitingForWriteLock.get(0);
            synchronized(writeLockedThread) {
                writeLockedThread.notifyAll();
            } // synchronized
        } // if
    }
    else if (Thread.currentThread() == writeLockedThread)
    {
        if (outstandingReadLocks == 0
              && waitingForWriteLock.size() > 0)
        {
            writeLockedThread = (Thread)waitingForWriteLock.get(0);
            synchronized(writeLockedThread) {
                writeLockedThread.notifyAll();
            } // synchronized
        }
        else
        {
            writeLockedThread = null;
            if (waitingForReadLock > 0)
                notifyAll();
        } // if
    }
    else
    {
        throw new IllegalStateException("Thread does not have lock");
    } // if
} // done()
} // class ReadWriteLock
}

