import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { CreateEvent, UpdateEvent} from "../../types/common";


const API_URL = import.meta.env.VITE_API_BASE_URL;


export const eventsApi = createApi({
    reducerPath: 'eventsApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${API_URL}/api` }),
    endpoints: (builder) => ({
        getAllEvents: builder.query({
            query: () => `events`,
        }),
        getEventById: builder.query({
            query: (eventId: string) => `events/${eventId}`,
        }),
        getEventByUserId: builder.query({
            query: (userId: string) => `events/users/${userId}`,
        }),
        createEvent: builder.mutation({
            query: (newEvent: CreateEvent) => ({
                url: `events`,
                method: 'POST',
                body: newEvent,
            }),
        }),
        updateEvent: builder.mutation({
            query: (data: { eventId: number, updatedEvent: UpdateEvent }) => ({
                url: `events/${data.eventId}`,
                method: 'PUT',
                body: data.updatedEvent,
            }),
        }),
        deleteEvent: builder.mutation({
            query: (eventId: number) => ({
                url: `events/${eventId}`,
                method: 'DELETE',
            }),
        })
    }),
});

export const {
    useGetAllEventsQuery,
    useGetEventByIdQuery,
    useGetEventByUserIdQuery,
    useCreateEventMutation,
    useUpdateEventMutation,
    useDeleteEventMutation
} = eventsApi;