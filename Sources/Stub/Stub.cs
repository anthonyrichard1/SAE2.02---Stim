﻿using Model;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace StimStub
{
    [ExcludeFromCodeCoverage]
    public class Stub : IPersistance
    {
        public List<Game> Games { get; set; }

        public Stub()
        {
            Games = LoadGame() ?? new();
        }

        public void SaveGame(List<Game> games)
        {
            foreach (Game game in games) if (!Games.Contains(game)) Games.Add(game);
        }

        public List<Game> LoadGame()
        {
            List<Game> tmp = new();

            tmp.Add(new("Elden Ring", "Elden Ring est un jeu de rôle d'action de 2022 qui a été développé par FromSoftware, publié par Bandai Namco Entertainment et réalisé par Hidetaka Miyazaki avec la construction du monde fournie par l'écrivain fantastique George R. R. Martin. Il est sorti sur PlayStation 4, PlayStation 5, Microsoft Windows, Xbox One et Xbox Series X / S le 25 février. Les joueurs contrôlent un personnage de joueur personnalisable qui est en quête de réparer l'Elden Ring et de devenir le nouveau Elden Lord.\r\n\r\nElden Ring est présenté à travers une perspective à la troisième personne; les joueurs parcourent librement son monde ouvert interactif. Les six zones principales sont traversées en utilisant le coursier Torrent du personnage du joueur comme principal mode de déplacement. Des donjons cachés linéaires peuvent être explorés pour trouver des objets utiles. Les joueurs peuvent utiliser plusieurs types d'armes et de sorts magiques, y compris l'engagement non direct activé par la mécanique furtive. Partout dans le monde du jeu, les points de contrôle permettent des déplacements rapides et permettent aux joueurs d'améliorer leurs attributs en utilisant une monnaie du jeu appelée Runes. Elden Ring propose un mode multijoueur en ligne dans lequel les joueurs peuvent se rejoindre pour des combats coopératifs et joueur contre joueur.\r\n\r\nLors de la planification, FromSoftware voulait créer un jeu en monde ouvert avec un gameplay similaire à Dark Souls ; la société voulait qu'Elden Ring agisse comme une évolution du premier titre éponyme de la série. Miyazaki admirait le travail de Martin, dont il espérait que les contributions produiraient un récit plus accessible que ceux des jeux précédents de la société. Martin a eu la liberté illimitée de concevoir la trame de fond tandis que Miyazaki était l'auteur principal du récit du jeu. Les développeurs se sont concentrés sur l'échelle environnementale, le jeu de rôle et l'histoire ; l'échelle a nécessité la construction de plusieurs structures à l'intérieur du monde ouvert.\r\n\r\nElden Ring a été acclamé par la critique; les critiques ont loué son monde ouvert, ses systèmes de jeu et son cadre, mais certains ont critiqué ses performances techniques. Il a remporté plusieurs prix du jeu de l'année et s'est vendu à plus de 20 millions d'exemplaires en un an. Une extension appelée Shadow of the Erdtree a été annoncée en février 2023.", 2022, new List<string> { "Action", "Solo", "RPG" }, "elden_ring.jpg", "https://www.instant-gaming.com/fr/4824-acheter-elden-ring-pc-jeu-steam-europe/"));
            tmp[0].AddReview(new("User 1", 5, "C'est trop bien"));
            tmp[0].AddReview(new("User 2", 3.5f, "C'est bien"));
            tmp[0].AddReview(new("User 3", 1.5f, "C'est pas bien"));
            tmp.Add(new("Minecraft", "Minecraft est un jeu vidéo de type aventure « bac à sable » (construction complètement libre) développé par le Suédois Markus Persson, alias Notch, puis par la société Mojang Studios. Il s'agit d'un univers composé de voxels et généré de façon procédurale, qui intègre un système d'artisanat axé sur l'exploitation puis la transformation de ressources naturelles (minéralogiques, fossiles, animales et végétales).\r\n\r\nMinecraft est à l'origine développé pour être un jeu sur navigateur Web, puis sur Windows, Mac et Linux (à l'aide de Java). Un portage sur téléphone mobile existe également, Minecraft Bedrock Édition, sortie sur les smartphones Android, sur les terminaux iOS, les appareils Windows Phone et est disponible sur Windows 10. Une version pour Xbox 360 est sortie le 9 mai 2012, développée par 4J Studios. Une version PlayStation 3 développée par Mojang est disponible depuis le 18 décembre 2013. La version PS4 est sortie le 4 septembre 2014 sur le PlayStation Store, la version Xbox One est publiée le lendemain tandis que la version Wii U est disponible en téléchargement sur le Nintendo eShop depuis le 17 décembre 2015 et en version physique depuis le 30 juin 2016. La version Nintendo Switch est sortie le 12 mai 2017 et la version pour New Nintendo 3DS le 14 septembre 2017.\r\n\r\nLa Minecon, un congrès en l'honneur de Minecraft, célèbre la sortie officielle du jeu le 18 novembre 2011. Disponible en 139 langues, le jeu vidéo est également décliné sous plusieurs formes physiques : papercraft (origami), produits dérivés (figurines, vêtements, peluches, etc.) et boîtes de jeu Lego.\r\n\r\nEn mai 2020, Minecraft a passé la barre des 200 millions d'exemplaires vendus sur toutes les plateformes, ce qui en fait à la fois le jeu vidéo le plus vendu de tous les temps et la septième franchise la plus vendue de tous les temps, avec une communauté de 126 millions de joueurs actifs par mois en mai 2020.", 2011, new List<string> { "Aventure", "Multijoueur", "Bac à sable" }, "minecraft.jpeg", "https://www.instant-gaming.com/fr/442-acheter-minecraft-java-et-bedrock-edition-pc-jeu/"));
            tmp[1].AddReview(new("User 1", 4.5f, "C'est trop bien"));
            tmp[1].AddReview(new("User 2", 3.5f, "C'est bien"));
            tmp[1].AddReview(new("User 3", 2, "C'est pas bien"));
            tmp.Add(new("Celeste", "Celeste est un jeu vidéo de plateforme indépendant en deux dimensions développé et édité par Extremely OK Gamesa, un studio canadien dirigé par Maddy Thorson et Noel Berry. Issu d'un prototype éponyme développé en août 2015 lors d'une game jam sur la fantasy console PICO-8, il est finalement publié sur Microsoft Windows, macOS, Linux, PlayStation 4, Nintendo Switch et Xbox One le 25 janvier 2018, puis sur Google Stadia le 28 juillet de la même année.\r\n\r\nDans Celeste, le joueur incarne Madeline, une jeune femme qui tente de gravir le mont Celeste. Au cours de son ascension, il est révélé qu'elle souffre d'une sévère forme d'anxiété et de dépression, impliquant qu'elle doit affronter ses angoisses et son mal-être intérieur pour parvenir au sommet de la montagne. Le jeu est composé de huit chapitres ainsi que d'un DLC gratuit intitulé Farewell, sorti le 9 septembre 2019, qui clôt définitivement l'histoire. Le gameplay du jeu consiste en une suite d'écrans présentant un assemblage complexe et cohérent d'obstacles qui demandent à la fois de la stratégie, de la précision et un bon temps de réaction de la part du joueur pour être surmontés. Jugé exigeant et souvent comparé à des jeux comme Super Meat Boy, Celeste inclut néanmoins des paramètres pour ajuster la difficulté et reste vu comme moins punitif que les autres jeux du genre.\r\nQuatre personnages regardent une fille rousse tenter d'attraper une fraise ailée ; le logo du jeu se trouve au-dessus.\r\nCouverture de la boîte du jeu.\r\n\r\nCeleste est très bien reçu par la critique et est loué pour ses mécaniques de jeu, son level design, sa musique — composée par Lena Raine —, son esthétique graphique 8 bits et son histoire, en particulier pour le travail effectué sur le personnage de Madeline ainsi que sur celui de représentation des troubles psychiques. Il est considéré par la presse spécialisée comme l'un des meilleurs jeux de 2018, remportant de nombreuses récompenses parmi lesquelles le prix du meilleur jeu indépendant aux Game Awards 2018 et une nomination en tant que jeu de l'année lors de cette même cérémonie. Il s'agit en outre d'un succès commercial, Celeste s'étant écoulé à plus d'un million d'exemplaires en mars 2020, tout en devenant très populaire dans la communauté du speedrun. ", 2018, new List<string> { "Plates-formes", "Solo", "Aventure" }, "celeste.png", "https://www.instant-gaming.com/fr/8003-acheter-celeste-pc-mac-jeu-steam/"));
            tmp[2].AddReview(new("User 1", 3, "C'est trop bien"));
            tmp[2].AddReview(new("User 2", 2.5f, "C'est bien"));
            tmp[2].AddReview(new("User 3", 0.5f, "C'est pas bien"));
            tmp.Add(new("GTA V", "Grand Theft Auto V (plus communément GTA V ou GTA 5) est un jeu vidéo d'action-aventure, développé par Rockstar North et édité par Rockstar Games. Il est sorti en 2013 sur PlayStation 3 et Xbox 360, en 2014 sur PlayStation 4 et Xbox One, en 2015 sur PC puis en 2022 sur PlayStation 5 et Xbox Series. Le jeu fait partie de la série vidéoludique Grand Theft Auto.\r\n\r\nCet épisode se déroule dans l'État fictif de San Andreas en Californie du Sud. L'histoire solo suit trois protagonistes : le braqueur de banque à la retraite Michael De Santa (avant l’accord avec le FIB : Michael Townley), le gangster Franklin Clinton et le trafiquant de drogue et d'armes Trevor Philips, et leurs braquages sous la pression d'une agence gouvernementale corrompue et de puissants criminels. Le jeu en monde ouvert permet aux joueurs de parcourir librement la campagne ouverte de San Andreas et la ville fictive de Los Santos, inspirée de Los Angeles.\r\n\r\nLe coût de Grand Theft Auto V, marketing compris, s'élève à 265 millions de dollars, ce qui représente à l'époque un record pour un jeu vidéo. Le jeu bat sept records de ventes lors de sa sortie et devient un grand succès commercial, dépassant 20 millions d'exemplaires vendus en deux semaines, ainsi que plus d’un milliards de dollars de recette. Le jeu reçoit le prix Golden Joystick pour le jeu de l'année, mais également le prix Game of the Year.\r\n\r\nAu mois de mai 2023, le jeu s'est écoulé à plus de 180 millions d'exemplaires tout support confondu, le plaçant à la deuxième place des jeux vidéo les plus vendus de tous les temps, derrière Minecraft", 2013, new List<string> { "Solo", "Tir", "Multijoueur" }, "gta_v.png", "https://www.instant-gaming.com/fr/186-acheter-grand-theft-auto-v-pc-jeu-rockstar/"));
            tmp[3].AddReview(new("User 1", 4.5f, "C'est trop bien"));
            tmp[3].AddReview(new("User 2", 2, "C'est bien"));
            tmp[3].AddReview(new("User 3", 1, "C'est pas bien"));

            return tmp;
        }

        public void SaveUser(HashSet<User> users)
        {
            foreach (User user in users) if (!users.Contains(user)) users.Add(user);
        }

        public HashSet<User> LoadUser()
        {
            HashSet<User> tmp = new();

            return tmp;
        }
    }
}