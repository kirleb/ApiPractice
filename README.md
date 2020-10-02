This is a project creating an api with entityframework, automapper and sql express.

When you retrieve all commands from URI http://5000/api/commands/ it returns a <CommandReadDto> object
which is more concise than the <Command> object.

When you retrieve a command from URI http://5000/api/commands/{id} it returns a <Command> object if
the id doesn't exist a 404 not found is returned.

When you create a command on URI http://5000/api/commands/ it returns a <Command> object and a 201
Created status code. If the command is missing a required input (they are all required except id which
is auto generated) then a 400 Bad Request is returned.


 