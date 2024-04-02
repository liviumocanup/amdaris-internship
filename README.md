# Assignment: Structural Design Patterns
### Assignment instructions

You are tasked with designing and implementing a text formatting tool that allows users to apply various formatting options to text, such as bold, italic, underline, and color. Your implementation should focus on applying the appropiate design patterns for this task. 

**Scenario**: The text formatting tool needs to support multiple formatting options and provide a unified interface for users to apply formatting to text. The system should allow users to apply formatting options in any order and combine multiple formatting options as needed.

**Functional Requirements**:

1. Implement multiple text formatting options such as bold, italic, underline, and color.
2. Allow users to apply formatting options to text strings.
3. Provide options for users to combine multiple formatting options and apply them to text.
4. Ensure that the system can remove applied formatting options from text.

You don't have to actually print the text with the chosen formats. You can simulate this by just printing in the console something like "This is a white text on black background with italic and bold"

## Decorator Pattern

Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors. I considered it the most fitting for these requirements since it provides a flexible and scalable solution to extend the functionality of the text formatting tool, specifically, it enables the application of multiple formatting options (such as bold, italic, underline, and color) in any combination and order.

## Facade Pattern

Facade is a structural design pattern that provides a simplified interface to a library, a framework, or any other complex set of classes. I considered it fitting for these requirements additionally since it provides a unified interface for users to apply formatting to text.