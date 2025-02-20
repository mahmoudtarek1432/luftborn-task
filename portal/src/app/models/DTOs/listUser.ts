export interface ListUser{
    name: string
    id: string
    email: string
    mobile: string
    role: 'ADMIN' | 'USER'
    selectedRole: 'ADMIN' | 'USER'
}