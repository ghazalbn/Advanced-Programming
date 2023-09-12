import A2

def test_PersonConstructor():
    person=A2.Person(97461495,"Amirali",[],{})
    assert person.Name == "Amirali"
    assert person.ID % 100 == 95

    person2=A2.Person(97521225,"Mohammad Hossein",[person],{person.ID:0})
    assert person2.Name == "Mohammad Hossein"
    assert person2.ID % 100 == 25
    assert len(person2.Contacts) == 1
    assert len(person2.Chats.keys()) == 1
    assert person2.Chats[97461495] == 0

def test_PersonAddContact():
    person=A2.Person(97423156,"Mohammad",[],{})
    person2=A2.Person(97521369,"Ramtin",[],{})
    person3=A2.Person(97216432,"َAlireza",[],{})

    person.AddContact(person2)
    assert person.Contacts[0].ID % 100 == 69
    assert person.Contacts[0].Name == "Ramtin"
    assert len(person2.Contacts) == 0
    
    person2.AddContact(person)
    person2.AddContact(person3)
    assert len(person2.Contacts) == 2
    assert person2.Contacts[1].ID % 100 == 32

def test_MessageConstructor():
    person1=A2.Person(97423156,"Mohammad",[],{})
    person2=A2.Person(97521369,"Ramtin",[],{})
    person3=A2.Person(97216432,"َAlireza",[],{})

    message12=A2.Message(person1,person2,"Slm Khubi?")
    message31=A2.Message(person2,person1,"Hello buddy!")

    assert message12.Source.Name=="Mohammad"
    assert len(message12.Source.Contacts) == 0
    assert message31.Context.split()[0]=="Hello"
    assert message12.Context.split()[0] + " " + message31.Context.split()[1] =="Slm buddy!"
    



def test_SendMessage(): 
    person1=A2.Person(97423156,"Mohammad",[],{})
    person2=A2.Person(97521369,"Ramtin",[],{})
    person3=A2.Person(97216432,"َAlireza",[],{})

    message12=A2.Message(person1,person2,"Slm Khubi?")
    message31=A2.Message(person3,person1,"Hello buddy!")

    person1.SendMessage(message12)
    person3.SendMessage(message31)
    assert len(person1.Chats) == 2
    assert (97521369 in person1.Chats.keys()) == True
    assert (97216432 in person1.Chats.keys()) == True
    

    val=[]
    for key, value in person1.Chats.items():
        for message in value:
            val.append(message.Context)
    assert ("Slm Khubi?" in val) == True
    assert ("Hello buddy!" in val) == True

