@startuml

skinparam pageExternalColor red

package "AppConsole" #fad6a7{

}

package "Model" #fad6a7{

}

package "Persistance" #fad6a7{

}

package "Stim" #fad6a7{

}

package "Stub" #fad6a7{

}

package "Test" #fad6a7{

}

AppConsole ..-> Model
AppConsole ..-> Persistance
AppConsole ..-> Stub

Persistance ..-> Model

Stim ..-> Model
Stim ..-> Persistance
Stim ..-> Stub

Stub ..-> Model

Test ..-> Model
Test ..-> Persistance
Test ..-> Stub

@enduml