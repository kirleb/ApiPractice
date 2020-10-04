This is a project creating an api with entityframework, automapper and sql express.

As this is a practice project there are some unnecessary details to help me learn.

When you retrieve all commands from URI http://localhost:5000/api/commands/ it returns a <CommandReadDto> object
which is more concise than the <Command> object.

When you retrieve a command from URI http://localhost:5000/api/commands/{id} it returns a <Command> object if 
the id doesn't exist a 404 not found is returned.

When you create a command on URI http://localhost:5000/api/commands/ it takes a <CommandCreateDto> and it returns 
a <Command> object and a 201 Created status code. If the command is missing a required input (they 
are all required except id which is auto generated) then a 400 Bad Request is returned.

When you use the PUT method on URI http://localhost:5000/api/commands/{id} it retrieves a <Command> object from the DB,
checks that it exists (if it doesn't it returns 404 not found), if it exists the command is changed to
the new <CommandUpdateDto> object and returns 204 NoContent.

When you use the PATCH method on URI http://localhost:5000/api/commands/{id} it retrieves a Command from the DB,
checks that it exists (if it doesn't it returns 404 not found),if it exists then it maps to a 
<CommandUpdateDto> object. Then it applies the patch and checks that Command is validated, if it is 
validated the command is changed to the new Command and returns 204 NoContent.

When you delete a command at URI http://localhost:5000/api/commands/{id} checks that it exists (returns not found
if not), and then returns 204 NoContent.



 