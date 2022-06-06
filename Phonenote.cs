using System;


[Serializable]

public struct Phonenote : IComparable<Phonenote>
{
    public string initials;
    public string phoneNumber;
    public int[] dateOfBirth;

    public Phonenote(string nameSurname, string phnumber, int[] date)
    {
        initials = nameSurname;
        phoneNumber = phnumber;
        dateOfBirth = date;
    }

    public override string ToString()
    {
        string info =
            $"{this.initials} {this.phoneNumber} {this.dateOfBirth[0]}.{this.dateOfBirth[1]}.{this.dateOfBirth[2]}";
        return info;
    }

    public int CompareTo(Phonenote other)
    {
        // 0-dd, 1-mm, 2-yy

        if (dateOfBirth[2] != other.dateOfBirth[2])
        {
            return dateOfBirth[2] - other.dateOfBirth[2];
        }
        if (dateOfBirth[1] != other.dateOfBirth[1])
        {
            return dateOfBirth[1] - other.dateOfBirth[1];
        }
        if (dateOfBirth[0] != other.dateOfBirth[0])
        {
            return dateOfBirth[0] - other.dateOfBirth[0];
        }
        return 0;

    }
}
