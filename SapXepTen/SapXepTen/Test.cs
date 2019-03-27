
class Person
{
    string vorname;
    string nachname;
    int age;

    public Person(string vorname, string nachname, int age)
    {
        this.age = age;
        this.nachname = nachname;
        this.vorname = vorname;
    }

    public int CompareTo(object obj)
    {
        Person other = (Person)obj;
        int a = this.age - other.age;

        if (a != 0)
        {
            return -a;
        }
        else
        {
            return age.CompareTo(other.age);
        }
    }

    public override string ToString()
    {
        return vorname + " " + nachname + "\t" + age;
    }
}
