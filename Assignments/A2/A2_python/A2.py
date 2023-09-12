class Person:
    ID = 0
    Name = ""
    Contacts = []
    Chats = {}
    def __init__(self,id,name,contacts,chats):
        self.ID = id
        self.Name = name
        self.Chats = chats
        self.Contacts = contacts

    def AddContact(self,PERSON):
        for p in self.Contacts:
            if p == PERSON:
                return
        self.Contacts.append(PERSON) 
        self.Chats.__setitem__(PERSON.ID, [])

    def SendMessage(self,message):
        message.Destination.AddContact(self)
        self.AddContact(message.Destination)
        message.Destination.Chats[self.ID].append(message)
        self.Chats[message.Destination.ID].append(message)

class Message:
    Source = Person(0,'',[],{})
    Destination = Person(0,'',[],{})
    Context = ""
    def __init__(self,source,destination,context):
        self.Source = source
        self.Destination = destination
        self.Context = context
