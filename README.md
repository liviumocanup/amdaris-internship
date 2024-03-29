# Assignment: Clean Code
## Assignment instructions
1. Take a look at the Speaker class in this GitHub repo: https://github.com/mustafadagdelen/dirty-code-for-clean-code-sample/blob/master/BusinessLayer/Speaker.cs
2. Create a console appliation and refactor the Speaker class from the repo, so that it adheres to clean code, SOLID principles and generally to good coding practices
3. Also create the other classes needed for the app to compile, like the Session class. Don't concentrate on refactoring them. Use them just for the purpose of your application to work
4. In a readme.md file, answer the following questions:
* What code smells did you see?
* What problems do you think the Speaker class has?
* Which clean code principles (or general programming principles) did it violate?
* What refactoring techniques did you use?

## Anwers to the questions
### What code smells did you see?

1. **Rigidity**: The `Speaker` class is a `God Object` since it has multiple responsibilities (properties definition, validation, registration logic), making it hard to change because it would cause a cascade of subsequent changes.

2. **Fragility**: Also due to the `Speaker` class being a `God Object` and managing both properties definition, as well as business logic, a single change would break the software in many places, which is also due to it not adhering to the SOLID principles.

3. **Immobility**: The previous considerations make the `Speaker` class a liability, requiring high effort to reuse parts of it's code due to it not adhering to KISS and SOLID.

4. **Needless Complexity**: The `Speaker` class has multiple responsibilities, especially the `Register` method which is very long and complex, making it hard to read, understand, and maintain. Moreover, it contains deeply nested conditionals, making the flow difficult to follow.

5. **Needless Repetition** can be seen in the validation of the `speaker's` fields (`firstName`, `lastName`, `email`, etc.).

6. **Opacity**: Also due to the `Register` method which manages validation and business logic, making it a very long, beefy and complex due to it's magic numbers, check and deep nests, the code is hard to understand and follow along.

### What problems do you think the Speaker class has?

1. **Not Modular Enough**: The `Speaker` class is a `God Object` and just the `Register` method is longer than 150 lines of code.

2. **Violation of Clean Code Principles**: The `Register` method contains deeply nested conditionals and is very long and complex, making the flow difficult to follow and understand. Moreover, it contains code duplication.

3. **Violation of Good Coding Practices**: Not following naming convensions (`nt`, `ot`, `emp`, etc.), magic numbers.

4. **Violation of SOLID**: The code has multiple responsibilities, is not open for extension without modification (especially fee calculation), etc.

### Which clean code principles (or general programming principles) did it violate?

* **Violation of SRP**: `Speaker` handles both the properties of a speaker and the business logic for registration
* **Violation of OCP**: The class is not open for extension without modification, especially the hardcoded validation and fee calculation.
* **Violation of DRY**: Code duplication in the validation of the `speaker`'s fields (`firstName`, `lastName`, `email`, etc.)
* **Violation of KISS**: The `Register` method contains deeply nested conditionals and is very long and complex, making the flow difficult to follow and understand
* **Naming Conventions**: Names like `nt`, `ot`, `emp`, etc. are not descriptive, making it hard to understand what they represent.
* **Magic Numbers**: Hardcoded values for `domains`, `required certifications number`, `required experience years`, etc.

### What refactoring techniques did you use?

1. **Separate Concerns**: Moved validation and fee calculation logic out of the `Speaker` class into separate services, in accordance with SRP.
1. **Use of Abstractions**: Introduced interfaces ( `ISpeakerValidationService`, `IFeeService`, etc.) to decouple the class from specific implementations.
2. **Remove Magic Numbers**: Replaced magic numbers with named constants to make the code more understandable.
3. **Decompose Conditional**: Complex conditional logic in the registration and validation process was refactored into clearer, more manageable logic within the new services.
4. **Rename Method/Variable**: Methods and variables were named to clearly describe their purpose, improving readability.
5. **Replace Conditional with Polymorphism**: Introduced interfaces for services to move towards using polymorphism to handle variations in behavior more cleanly, especially with validation logic.