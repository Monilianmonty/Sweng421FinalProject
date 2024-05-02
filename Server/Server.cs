using System.Diagnostics;
using System.Reflection;

namespace Server
{

}

public class Bid
{
    private int bid = 0;
    private ReadWriteLock lockManager = new ReadWriteLock();
    //...
    public int getBid() throws InterruptedException
    {
        lockManager.readLock();
          int bid = this.bid;
    lockManager.done();
          return bid;
     } // getBid()

public void setBid(int bid) throws InterruptedException
{
    lockManager.writeLock();
          if (bid > this.bid) {
        this.bid = bid;
    } // if
    lockManager.done();
} // setBid(int)
} // class Bid

public class ReadWriteLock
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