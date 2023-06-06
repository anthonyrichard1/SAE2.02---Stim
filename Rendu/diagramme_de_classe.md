```plantuml
@startuml

hide circle
allowmixing
skinparam classBackgroundColor #f89f40
skinparam namespaceBackgroundColor #fcb773 

namespace Model #fcb773{
    class Game{
        +/Name:string
        +/Description:string
        +/Lien:string
        +/Cover:string
        +/Year:int
        +/Average:float
        +/Tags:ObservableCollection<string>

        +Game(name:string, description:string, year:int, c_tags:List<string>, cover:string, c_lien:string):void
        -NotifyPropertyChanged(propertyName:string):void
        +GetHashCode():int
        +Equals(obj:object?):bool
        +Equals(other:Game?):bool
        +ToString():string
        +AddReview(review:Review):void
        +RemoveReview(review:Review):void
        +NameChange(newName:string):void
        +DescChange(newDesc:string):void
        +TagChange(newTag:List<string>):void
        +YearChange(newYear:int):void
    }

    class User{
        +/Username:string
        +/Biographie:string
        +/Email:string
        +/Password:string
        +/UserImage:string

        +User(userImage:string, username:string, biographie:string, email:string, password:string):void
        -NotifyPropertyChanged(propertyName:string):void
        +Equals(other:User):bool
        +Equals(obj:object):bool
        +GetHashCode():int
        +AddReview(game:Game, rate:float, text:string):void
        +RemoveSelfReview(game:Game, rate:float, text:string):void
        +FollowAGame(game:Game):void
        +RemoveAGame(game:Game):void
        +ToString():string
    }

    class Review{
        +/Rate:float
        +/Text:string
        +/AuthorName:string

        +ToString():string
        +EditReview(text:string):void
        +EditRate(newVal:float):void
    }

    class Manager{
        -Mgrpersistance:IPersistance
        
        +Manager(persistance:IPersistance)
        +FilterGames():IEnumerable<Game>
        +AddGametoGamesList(game:Game):void
        +RemoveGameFromGamesList(game:Game):void
        +AddUserToUserList(user:User):void
        +SearchUser(username:string):User
        +SaveUser():void
        +SaveGames():void
    }

    class IPersistance{
        {abstract}SaveGame(games:List<Game>):void
        {abstract}SaveUser(users:HashSet<User>):void
        {abstract}LoadGame():List<Game>
        {abstract}LoadUser():HashSet<User>
    }

    Game "0, n" *-> Review: "+/Reviews:List<Review>"
    User "0, n" o----> Game: "+/FollowedGames:ObservableCollection<Game>"
    Manager "1, 1" *--> IPersistance: "-mgrpersistance:IPersistance"
    Manager "0, n" *-> Game: "-/GameList:List<Game>"
    Manager "0, 1" o-> User: "+/CurrentUser:User"
    Manager "0, 1" o-> Game: "+/SelectedGame:Game"
    Manager "0, n" *--> User: "+/Users:HashSet<User>"
}

namespace StimPersistance #fcb773{
    class Persistance{
        +Persistance(chemin:string):void
        +SaveGame(games:List<Game>):void
        +SaveUser(users:HashSet<User>):void
        +LoadGame():List<Game>
        +LoadUser():HashSet<User>
    }

    Model.IPersistance <|- Persistance
}

namespace StimStub #fcb773{
    class Stub{
        +Stub(chemin:string):void
        +SaveGame(games:List<Game>):void
        +SaveUser(users:HashSet<User>):void
        +LoadGame():List<Game>
        +LoadUser():HashSet<User>
    }
    Stub "0, n" o--> Model.Game: "+/Games:ObservableCollection<Game>"
    Model.IPersistance <|-- Stub
}

@enduml