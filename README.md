# Assignment: Behavioral Design Patterns
### Assignment instructions

You are tasked with designing and implementing an order processing system for an online bookstore. The system should allow users to place orders for books and process those orders efficiently. Your implementation should focus on applying a specific behavioral design pattern that addresses the requirements of the scenario.

**Functional Requirements**:
1. When a customer places an order, they should receive notifications about the order status updates via email or SMS (Use just Console.WriteLine to simulate sending and email or SMS)
2. Staff members responsible for order fulfillment should receive notifications when new orders are placed and when orders are ready for shipping.
3. Implement a mechanism for customers and staff to subscribe or unsubscribe from order status notifications.
4. Everything should be implemented in one single console application

## Observer Pattern

The Observer Pattern is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing. I considered it the most fitting for these requirements since the task involves a dynamic and interactive order processing system where multiple parties (customers and staff) need real-time updates on the order status.