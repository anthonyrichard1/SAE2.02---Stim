@startuml

namespace Model #fad6a7{
    class Game{
        /Name:string
        /Description:string
        /Lien:string
        /Cover:string
        /Year:int
        /Average:float
        /Tags:ObservableCollection<string>

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
        /Username:string
        /Biographie:string
        /Email:string
        /Password:string

        +User(username:string, biographie:string, email:string, password:string):void
        +AddReview(game:Game, rate:float, text:string):void
        +RemoveSelfReview(game:Game, rate:float, text:string):void
        +FollowAGame(game:Game):void
        +RemoveAGame(game:Game):void
    }

    class Review{
        /Rate:float
        /Text:string
        /AuthorName:string
        +ToString():string
        +EditReview(text:string):void
        +EditRate(newVal:float):void
    }

    class Manager{
        +GameList:ObservableCollection
        +Manager(persistance:IPersistance)
        
    }

    class Ipersistance{
        {abstract}SaveGame(games:ObservableCollection<Game>):void
        {abstract}SaveUser(users:List<User>):void
        {abstract}LoadGame():ObservableCollection<Game>
        {abstract}LoadUser():List<User>
    }

    Game "/Reviews:List<Review>" *-- Review
    User "/FollowedGames:List<Game>" o-- Game
    Manager "/Mgrpersistance:IPersistance" *-- IPersistance
}

































@enduml