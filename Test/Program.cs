﻿using System;


namespace ConsoleApplication10
{
    public interface iOverrideQueue
    {
        //Add a task to the Queue.
        //priority will always be provided as a non-negative integer (zero is valid)
        //zero (0) is the lowest priority, max priority is only limited by the integer type.  
        //This is given, it does not need to be enforced.
        void addTask(String taskDescription, int priority);

        //Return the "next" task based on the rules above and remove it from the queue.
        //If the Queue is empty, return null.
        String nextTask();
    }

    public class myQueue : iOverrideQueue
    {
        public Task[] taskQueue;
        public int tqSize;
        public int tqAddedTasks;
        public int nextPointer = 0;

        public myQueue(int size)
        {
            tqSize = size;
            taskQueue = new Task[tqSize];
            tqAddedTasks = 0;
        }

        public bool isEmpty()
        {
            return tqAddedTasks == 0;
        }

        public bool isFull()
        {
            return tqAddedTasks == tqSize - 1;
        }

        public void addTask(string taskDescription, int priority)
        {
            Task task = new Task(taskDescription, priority);
            taskQueue[++tqAddedTasks] = task;
            int count = tqAddedTasks;

            while (count != 1 && task.priority > taskQueue[count - 1].priority)
            {
                taskQueue[count] = taskQueue[count - 1];
                count--;
            }
            taskQueue[count] = task;
            nextPointer = 0;

        }
        public string nextTask()
        {
            if (!isEmpty())
            {
                nextPointer++;
                return taskQueue[nextPointer].taskDescription;
            }
            return "Queue is empty";
        }
    }

    public class Task
    {
        public string taskDescription;
        public int priority;

        public Task(string TaskDescription, int Priority)
        {
            taskDescription = TaskDescription;
            priority = Priority;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            iOverrideQueue oq = null;

            //Implement the interface above so that "myQueue" is valid.
            oq = new myQueue(20);

            // Sample test data/code
            oq.addTask("first", 1);
            oq.addTask("second", 1);
            oq.addTask("third", 3);
            oq.addTask("fourth", 1);
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            oq.addTask("fifth", 1);
            oq.addTask("sixth", 5);
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            oq.addTask("seventh", 1);
            oq.addTask("eighth", 2);
            oq.addTask("ninth", 2);
            oq.addTask("tenth", 3);
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.WriteLine("GetNext(): " + oq.nextTask());
            Console.ReadLine();

            //The output for the above should be: 
            //GetNext(): third
            //GetNext(): first

            //GetNext(): sixth
            //GetNext(): second
            //GetNext(): fourth
            //GetNext(): fifth
            //GetNext(): 

            //GetNext(): tenth
            //GetNext(): eight
            //GetNext(): ninth
            //GetNext(): seventh

            //Note:  A different set of test data will be used for testing than is provided above. This needs to be an all purpose solution.
        }
    }



}