import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { Tag } from "../../types/common";

const API_URL = import.meta.env.VITE_API_BASE_URL;

export const tagsApi = createApi({
    reducerPath: "tagsApi",
    baseQuery: fetchBaseQuery({ baseUrl: `${API_URL}/api` }),
    endpoints: (builder) => ({
        getTags: builder.query<Tag[], void>({
            query: () => 'tags',
        }),
      
        getTagById: builder.query<Tag, number>({
            query: (id) => `tags/${id}`,
        }),
    }),
});
