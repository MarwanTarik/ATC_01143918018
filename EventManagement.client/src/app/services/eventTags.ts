import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { EventTag } from "../../types/common";


const API_URL = import.meta.env.VITE_API_BASE_URL;

export const eventTagsApi = createApi({
    reducerPath: "eventTagsApi",
    baseQuery: fetchBaseQuery({ baseUrl: `${API_URL}/api` }),
    endpoints: (builder) => ({
        getEventTags: builder.query<EventTag[], number>({
            query: (eventId) => `events/${eventId}/tags`,
        }),
        
        addTagsToEvent: builder.mutation<void, {eventId:number, tagIds: number[]}>({
            query: ({ eventId, tagIds }) => ({
                url: `events/${eventId}/tags`,
                method: "POST",
                body: { tagIds },
            }),
        }),

        deleteTagsFromEvent: builder.mutation<void, { eventId: number; tagIds: number[]}>({
            query: ({ eventId, tagIds }) => ({
                url: `events/${eventId}/tags`,
                method: "DELETE",
                body: { tagIds },
            }), 
        }),
    }),
})
