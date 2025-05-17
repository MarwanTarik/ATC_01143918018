import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { CreateBook } from "../../types/common";

const API_URL = import.meta.env.VITE_API_BASE_URL;

export const bookingApi = createApi({
    reducerPath: 'bookingApi',
    baseQuery: fetchBaseQuery({ baseUrl: `${API_URL}/api` }),
    endpoints: (builder) => ({
        getBooking: builder.query({
            query: (eventId:number) => `booking/events/${eventId}`,
        }),
        
        
        createBooking: builder.mutation({
            query: (data: { eventId: number, newBooking: CreateBook }) => ({
                url: `booking/events/${data.eventId}`,
                method: 'POST',
                body: data.newBooking,
            }),
        }),
        
        
        getAllBookings: builder.query({
            query: () => `booking`,
        }),
    }),
});

