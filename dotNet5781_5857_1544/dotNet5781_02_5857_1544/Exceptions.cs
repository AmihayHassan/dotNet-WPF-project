﻿using System;
using System.Runtime.Serialization;


#region NotInIsraelException
[Serializable]
public class NotInIsraelException : Exception
{
    public NotInIsraelException() : base() {}

    public NotInIsraelException(string message) : base(message) {}
}
#endregion

#region StationAlreadyExistsException
[Serializable]
public class StationAlreadyExistsException : Exception
{
    public StationAlreadyExistsException() : base() { }

    public StationAlreadyExistsException(string message) : base(message) { }
}
#endregion

#region StationDoesNotExistException
[Serializable]
public class StationDoesNotExistException : Exception
{
    public StationDoesNotExistException() : base() { }

    public StationDoesNotExistException(string message) : base(message) { }
}
#endregion

#region OutOfRangeException
[Serializable]
public class OutOfRangeException : Exception
{
    public OutOfRangeException() : base() { }

    public OutOfRangeException(string message) : base(message) { }
}
#endregion

#region TooLongException
[Serializable]
public class TooLongException : Exception
{
    public TooLongException() : base() { }

    public TooLongException(string message) : base(message) { }

    override public string ToString()
    { return "Can't ride over 1 hour without stop, you tried to ride" + Message + "\n"; }
}
#endregion

#region BusLineAlreadyExistsException
[Serializable]
public class BusLineAlreadyExistsException : Exception
{
    public BusLineAlreadyExistsException() : base() { }

    public BusLineAlreadyExistsException(string message) : base(message) { }
}
#endregion

#region BusLineDoesNotExistsException
[Serializable]
public class BusLineDoesNotExistsException : Exception
{
    public BusLineDoesNotExistsException() : base() { }

    public BusLineDoesNotExistsException(string message) : base(message) { }
}
#endregion
