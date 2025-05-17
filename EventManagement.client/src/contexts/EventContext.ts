import { createContext, type Dispatch, type SetStateAction } from "react";

const EventContext = createContext<
[Event | null, Dispatch<SetStateAction<Event | null>>]
>([null, () => null]);

export {
    EventContext
}