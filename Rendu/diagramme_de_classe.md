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
        +GetHashCode():int
        +Equals(obj:object?):bool
        +Equals(other:Game?):bool
        +ToString():string
        +GetAvgRate():float
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
        +AddReview(game:Game, rate:float, text:string):void
        +RemoveSelfReview(game:Game, rate:float, text:string):void
        +FollowAGame(game:Game):void
        +RemoveAGame(game:Game):void
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
        +Mgrpersistance:IPersistance
        +Manager(persistance:IPersistance)
        +AddGametoGamesList(game:Game):void
        +RemoveGameFromGamesList(game:Game):void
        +SaveGames():void
    }

    class IPersistance{
        {abstract}SaveGame(games:ObservableCollection<Game>):void
        {abstract}SaveUser(users:List<User>):void
        {abstract}LoadGame():ObservableCollection<Game>
        {abstract}LoadUser():List<User>
    }

    Game *- Review: "+/Reviews:List<Review>"
    User o- Game: "+/FollowedGames:ObservableCollection<Game>"
    Manager *-- IPersistance: "+/Mgrpersistance:IPersistance"
    Manager *-- Game: "+/GameList:ObservableCollection<Game>" 
    Manager o-- Game: "+/ReserchedGame:ObservableCollection<Game>"
    Manager o-- User: "+/CurrentUser:User"
}

namespace StimPersistance #fcb773{
    class Persistance{
        +Persistance(chemin:string):void
        +SaveGame(games:ObservableCollection<Game>):void
        +SaveUser(users:List<User>):void
        +LoadGame():ObservableCollection<Game>
        +LoadUser():List<User>
    }

    Persistance <|-- Model.IPersistance
}

namespace StimStub #fcb773{
    class Stub{
        +Stub(chemin:string):void
        +SaveGame(games:ObservableCollection<Game>):void
        +SaveUser(users:List<User>):void
        +LoadGame():ObservableCollection<Game>
        +LoadUser():List<User>
    }

    Stub o-- Model.Game: "+/Games:ObservableCollection<Game>"
    Stub <|- Model.IPersistance
}

@enduml